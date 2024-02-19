import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getProductList } from "../../../store/reducers/catalogReduser";
import { PageInfo } from "../../../store/types";
import { ProductTypesEnum } from "../../../store/enums/productTypesEnum";
import styled from "styled-components";
import { ProductCard } from "../../common/ProductCard";
import { Filter } from "./Filter";


const Container = styled.main`
  margin: 0 2%;
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




export const CatalogPage = () => {
  const catalogStore = useAppSelector(state => state.catalogStore);
  const dispatch = useAppDispatch();


  const pageInfoInitial: PageInfo = {
    groupBy: window.screen.width >= 1200 ? 15 : 10,
    page: 1,
    typeId: undefined
  }
  const [pageInfo, setPageInfo] = useState<PageInfo>(pageInfoInitial);






  const addToCart = (id: number) => {
    /*to do*/
    console.log(`add ${id} to cart`);
  }

  const goToDetail = (id: number) => {
    /*to do*/
    console.log(`go to ${id} detail`);
  }

  useEffect(() => {


    dispatch(getProductList(pageInfo))
  },
    [dispatch]);


  useEffect(() => {
    console.log("list");
    console.log(catalogStore.list);
    console.log("total pages");
    console.log(catalogStore.totalPagesNumber);
  });


  return (
    <Container>
      <Title>Catalog</Title>
      <Filter/>
      <List>
        {catalogStore.list.map(p => (<ProductCard key={p.id} product={p} addToCart={addToCart} goToDetail={goToDetail} />))}
      </List>


    </Container>
  )
}
