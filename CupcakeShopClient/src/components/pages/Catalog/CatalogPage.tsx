import { useEffect, useState } from "react";
import { useLocation, useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getProductList } from "../../../store/reducers/catalogReduser";
import { PageInfo } from "../../../store/types";
import { ProductTypesEnum } from "../../../store/enums/productTypesEnum";
import styled from "styled-components";
import { ProductCard } from "../../common/ProductCard";
import { Filter } from "./Filter";
import ArowImage from '../../../assets/images/ProductNavigationArrow.png';
import { BreadCrumbs, BreadCrumbsItem } from "../../common/BreadCrumbs";


const Container = styled.main`
  margin: 0 5%;
`;


const List = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr;
  margin: 1rem 0;
  gap: 1rem;

  .productCard{
    justify-self:center;
  }

  @media (min-width: 958px) {
    margin: 1rem 0;
  }

  @media (min-width: 1356px) {
    grid-template-columns: 1fr 1fr 1fr;
  }

`;


const Title = styled.div`
  font-family: var(--font-family-title);
  font-size: var(--text-size-huge-mobil);
  text-align: center;
  margin: 1rem 0;
  @media (min-width: 958px) {
    font-size: var(--text-size-huge);
  }

`;

const ProductPageNavigationContainer = styled.nav`
  display: flex;
  justify-content: center;
  margin: 3rem 0;
  gap: 10px;

  .selected{
    cursor: none;
    color: var(--color-dark);
  }

  @media (min-width: 767px) {
    margin-left: 65px;
  }

`;
const ProductPageNavigationNumber = styled.div`
  cursor: pointer;
  font-size: var(--text-size-large);
  color: var(--color-unselected-page);
`;
const ProductPageNavigationElement = styled.div`
  cursor: pointer;
  margin: 0 1rem;
  background-color: var(--color-dark);
  border-radius: 50%;
  width: 35px;
  height: 35px;
`;
const LeftArrow = styled.img`
  padding-left: 6px;
  padding-top: 12px;
`;
const RightArrow = styled.img`
  transform: rotate(180deg);
  padding-right: 6px;
  padding-bottom: 12px;
`;

const BreadCrumbsContainer = styled.div`
    margin: 2rem 0;
`;


export const CatalogPage = () => {
  const catalogStore = useAppSelector(state => state.catalogStore);
  const navigate = useNavigate();
  const [totalPagesArray, setTotalPagesArray] = useState<number[]>([]);
  const dispatch = useAppDispatch();
  const location = useLocation();

  const [defaultFilterValue] = useState(location.state);

  const pageInfoInitial: PageInfo = {
    groupBy: window.screen.width >= 1200 ? 15 : 10,
    page: 1,
    typeId: undefined
  }
  const [pageInfo, setPageInfo] = useState<PageInfo>(pageInfoInitial);


  const filterOnChangeHandler = (productType?: ProductTypesEnum) => {
    const updatedPageInfo = { ...pageInfo, typeId: productType, page: 1 };

    dispatch(getProductList(updatedPageInfo))
    setPageInfo(updatedPageInfo);

  }

  const navToPageByNumber = (pageN: number) => {
    if (pageN > 0 && pageN <= totalPagesArray.length) {
      const updatedPageInfo = { ...pageInfo, page: pageN };

      dispatch(getProductList(updatedPageInfo))
      setPageInfo(updatedPageInfo);
      window.scrollTo(0, 0);
    }
  }

  const addToCart = (id: number) => {
    /*to do*/
    console.log(`add ${id} to cart`);
  }

  const goToDetail = (id: number) => {
    navigate(`/catalog/product?id=${id}`);
  }

  const breadCrumbsList: BreadCrumbsItem[] = [
    { title: "Home", link: "/" },
    { title: "Catalog", link: null }
  ];


  useEffect(() => {
    window.scrollTo(0, 0);
    dispatch(getProductList(pageInfo))
  },
    [dispatch]);


  useEffect(() => {
    if (catalogStore.totalPagesNumber) {
      const totalPagesArray: number[] = Array.from({ length: catalogStore.totalPagesNumber }, (_, i) => i + 1);
      setTotalPagesArray(totalPagesArray);
    }

  }, [catalogStore]);


  useEffect(() => {
    navigate(".", { replace: true });
    if (defaultFilterValue) {
      const { productType } = defaultFilterValue;
      filterOnChangeHandler(productType)
    }
  }, [navigate]);




  return (
    <Container>
      <BreadCrumbsContainer>
        <BreadCrumbs breadCrumbsList={breadCrumbsList} />
      </BreadCrumbsContainer>
      <Title>Catalog</Title>
      <Filter filterOnChange={filterOnChangeHandler} defaultProductType={defaultFilterValue?.productType} />
      <List>
        {catalogStore.list.map(p => (<ProductCard key={p.id} product={p} addToCart={addToCart} goToDetail={goToDetail} />))}
      </List>
      <ProductPageNavigationContainer>
        <ProductPageNavigationElement onClick={() => { navToPageByNumber(pageInfo.page - 1) }}>
          <LeftArrow src={ArowImage} alt='lefr arrow' />
        </ProductPageNavigationElement>

        {totalPagesArray.map(n => (
          <ProductPageNavigationNumber key={n} className={pageInfo.page === n ? "selected" : ""} onClick={() => { navToPageByNumber(n) }}>
            {totalPagesArray.length === n ? n : n + ","}
          </ProductPageNavigationNumber>))}

        <ProductPageNavigationElement onClick={() => { navToPageByNumber(pageInfo.page + 1) }}>
          <RightArrow src={ArowImage} alt='right arrow' />
        </ProductPageNavigationElement>

      </ProductPageNavigationContainer>

    </Container>
  )
}
