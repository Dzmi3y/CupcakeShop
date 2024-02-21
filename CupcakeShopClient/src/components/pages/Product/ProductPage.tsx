import { useNavigate, useSearchParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getAdditionalParams, getDetailProductInfo, getRecommendedProducts } from "../../../store/reducers/detailProductReducer";
import { useEffect } from "react";
import styled from "styled-components";
import { BreadCrumbs, BreadCrumbsItem } from "../../common/BreadCrumbs";
import { ProductImgSlider } from "./ProductImgSlider";
import { Dropdown, DropdownItem } from "../../common/Dropdown";
import { ProductDetailDescription } from "./ProductDetailDescription";
import { ProductCard } from "../../common/ProductCard";
import { Product } from "../../../store/types";

const Container = styled.main`
  margin: 0 2%;
`;

const HeadContainer = styled.div`

`;

const ImgSliderContainer = styled.div`
  width: 300px;
`;

const MainContentContainer = styled.div`

`;

const RecommendationsContainer = styled.div`
display: grid;
grid-template-columns: 1fr 1fr;
gap: 2rem;
@media (min-width: 767px) {
grid-template-columns: 1fr 1fr 1fr;
}

`;

const BreadCrumbsContainer = styled.div`
  margin: 2rem 0 0 2%;
  @media (min-width: 767px) {
        margin: 2rem 0 0 8%;
  }
`;

const Title = styled.div`
  font-size: var(--text-size-extra-large);
  font-family: var(--font-family-light);
`;

const Price = styled.div`
  font-size: var(--text-size-large);
  font-family: var(--font-family-light);
`;

const OrderButton = styled.button`
  background-color: var(--color-dark);
  color: var(--color-light);
  font-size: var(--text-size-large);
  font-family: var(--font-family-light);
  width: 287px;
  height: 68px;
  border-radius: 10px;
`;

const ShortDescriptionList = styled.ul`
  &::marker{
        color: var(--color-dark);
        font-size: 2rem;
    }
`;

const ShotrDescriptionItem = styled.li`
  text-transform: lowercase;
  font-size: var(--text-size-medium);
  font-family: var(--font-family-light);
`;

const DropdownContainer = styled.div`
  width: 287px;
`;

export const ProductPage = () => {
  const navigate = useNavigate();
  const [queryParameters] = useSearchParams();
  const id = queryParameters.get("id");
  const detailProductStore = useAppSelector(state => state.detailProductStore);
  const dispatch = useAppDispatch();

  const delivery: string = detailProductStore.productInfo?.delivery ?? "";
  const description: string = detailProductStore.productInfo?.description ?? "";
  const storageConditions: string = detailProductStore.productInfo?.storageConditions ?? "";
  const recommendedProducts: Product[] = detailProductStore.recommendedProducts ?? [];

  const testList: DropdownItem[] = [
    { id: 1, text: "test 1" },
    { id: 2, text: "test 2" },
    { id: 3, text: "test 3" },
    { id: 4, text: "test 4" }
  ]

  useEffect(() => {
    const isMobil = window.screen.width < 767;
    console.log(isMobil);
    dispatch(getDetailProductInfo(Number(id)));
    dispatch(getAdditionalParams(Number(id)));
    dispatch(getRecommendedProducts({
      id: Number(id),
      count: isMobil ? 4 : 3
    }));
  }, [dispatch]);

  let breadCrumbsList: BreadCrumbsItem[] = [];
  if (detailProductStore.productInfo) {
    breadCrumbsList = [
      { title: "Home", link: "/" },
      { title: "Catalog", link: "/catalog" },
      { title: detailProductStore.productInfo.name, link: null }
    ];
  }

  const addRecomendationProductToCart = (id: number) => {
    /*to do*/
    console.log(`add ${id} to cart`);
  }

  const goToRecomendationProductDetail = (id: number) => {
    navigate(`/catalog/product?id=${id}`);
  }

  const OrderButtonClickHandler = () => {
    /*To Do*/
    console.log("order button clicked")
  }

  const dropdown1Selected = (id: number) => {
    console.log("selected");
    console.log(id);
  }


  return (

    <Container>
      <BreadCrumbsContainer>
        <BreadCrumbs breadCrumbsList={breadCrumbsList} />
      </BreadCrumbsContainer>
      <HeadContainer>
        <ImgSliderContainer>
          <ProductImgSlider urls={detailProductStore.productInfo?.allImgUrls} />
        </ImgSliderContainer>
        <MainContentContainer>

          <Title></Title>

          <ShortDescriptionList>
            <ShotrDescriptionItem> </ShotrDescriptionItem>
          </ShortDescriptionList>

          <DropdownContainer>
            <Dropdown list={testList} onSelected={dropdown1Selected} />
          </DropdownContainer>

          <br />
          <br />
          <br />

          <Price />

          <OrderButton>To order</OrderButton>

        </MainContentContainer>
      </HeadContainer>

      <ProductDetailDescription delivery={delivery} description={description} storageConditions={storageConditions} />

      <RecommendationsContainer>
        {recommendedProducts.map(p => (<ProductCard key={p.id} product={p} addToCart={addRecomendationProductToCart} goToDetail={goToRecomendationProductDetail} />))}
      </RecommendationsContainer>

    </Container>
  )
}
