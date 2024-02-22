import { useNavigate, useSearchParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getAdditionalParams, getDetailProductInfo, getRecommendedProducts } from "../../../store/reducers/detailProductReducer";
import { useEffect, useState } from "react";
import styled from "styled-components";
import { BreadCrumbs, BreadCrumbsItem } from "../../common/BreadCrumbs";
import { ProductImgSlider } from "./ProductImgSlider";
import { Dropdown, DropdownItem } from "../../common/Dropdown";
import { ProductDetailDescription } from "./ProductDetailDescription";
import { ProductCard } from "../../common/ProductCard";
import { AdditionWeight, AdditionalProductParameter, Product } from "../../../store/types";

const Container = styled.main`
  margin: 0 5%;
`;

const HeadContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 3rem;
  @media (min-width: 1332px) {
    flex-direction: row;
  }

`;

const ImgSliderContainer = styled.div`
 max-width: 500px;
`;

const MainContentContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 2rem;
  @media (min-width: 1332px) {
    display: grid;
    grid-template-columns: 1fr 1fr;
  }
`;

const RecommendationsContainer = styled.div`
display: grid;
grid-template-columns: 1fr 1fr;
gap: 2rem;
margin-bottom:2rem;
@media (min-width: 767px) {
  grid-template-columns: 1fr 1fr 1fr;
}
`;

const BreadCrumbsContainer = styled.div`
        margin: 2rem 0 ;
`;

const Title = styled.div`
  font-size: var(--text-size-extra-large);
  font-family: var(--font-family-light);
  grid-column-start: 1;
  grid-column-end: 3;
`;

const RecommendationsTitle = styled.div`
  font-size: var(--text-size-extra-large);
  font-family: var(--font-family-light);
  margin-bottom: 2rem;
`;

const Price = styled.div`
  font-size: var(--text-size-large);
  font-family: var(--font-family-light);
  grid-column-start: 1;
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
  padding-left: 18px;
  grid-column-start: 1;
  grid-column-end: 3;
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

const ProductDetailDescriptionContainer = styled.div`
  
  height: 300px;
  padding-top: 2rem;
  
  @media (min-width: 1332px) {
    max-width: 605px;
  }
`;

export const ProductPage = () => {
  const navigate = useNavigate();
  const [queryParameters] = useSearchParams();
  const id = queryParameters.get("id");
  const detailProductStore = useAppSelector(state => state.detailProductStore);
  const dispatch = useAppDispatch();

  const { delivery = "", description = "", storageConditions = "" } = detailProductStore.productInfo || {};
  const { decorations = [], subspecies = [], weights = [] } = detailProductStore.additionalProdParams || {};
  const recommendedProducts: Product[] = detailProductStore.recommendedProducts || [];
  const defaultPrice: number = detailProductStore.productInfo?.price || 0

  const [currentDecoration, setCurrentDecoration] = useState<AdditionalProductParameter>(decorations[0]);
  const [currentSubspecies, setCurrentSubspecies] = useState<AdditionalProductParameter>(subspecies[0]);
  const [currentAdditionalWeight, setCurrentAdditionalWeight] = useState<AdditionWeight>(weights[0]);

  const decorationsDropdownList: DropdownItem[] =
    decorations.map<DropdownItem>((d) => ({ id: d.id, text: d.name }));
  const subspeciesDropdownList: DropdownItem[] =
    subspecies.map<DropdownItem>((d) => ({ id: d.id, text: d.name }));
  const weightsDropdownList: DropdownItem[] =
    weights.map<DropdownItem>((d) => ({ id: d.id, text: (d.weight === 0) ? "Default weight" : "+ " + d.weight.toString() + d.unitOfMeasurement }));

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

  const orderButtonClickHandler = () => {
    /*To Do*/
    console.log("order button clicked")
  }

  const dropdownDecorationsSelected = (id: number) => {
    const decoration = decorations.find(d => d.id === id);
    if (decoration) {
      setCurrentDecoration(decoration);
    }
  }

  const dropdownSubspeciesSelected = (id: number) => {
    const selectedSubspecies = subspecies.find(s => s.id === id);
    if (selectedSubspecies) {
      setCurrentSubspecies(selectedSubspecies);
    }
  }

  const dropdownWeightsSelected = (id: number) => {
    const weight = weights.find(d => d.id === id);
    if (weight) {
      setCurrentAdditionalWeight(weight);
    }
  }

  const getTotalprice = () => {
    return defaultPrice
      + (currentDecoration?.price ?? 0)
      + (currentSubspecies?.price ?? 0)
      + (currentAdditionalWeight?.price ?? 0);
  }

  useEffect(() => {
    window.scrollTo(0, 0);
    const isMobil = window.screen.width < 767;
    dispatch(getDetailProductInfo(Number(id)));
    dispatch(getAdditionalParams(Number(id)));
    dispatch(getRecommendedProducts({
      id: Number(id),
      count: isMobil ? 4 : 3
    }));
  }, [dispatch]);


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

          <Title>{detailProductStore.productInfo?.name}</Title>

          <ShortDescriptionList>
            {detailProductStore.productInfo?.listOfshortDetails.map((d, i) => (
              <ShotrDescriptionItem key={i}>{d}</ShotrDescriptionItem>
            ))}

          </ShortDescriptionList>

          <DropdownContainer>
            <Dropdown list={decorationsDropdownList} onSelected={dropdownDecorationsSelected} />
          </DropdownContainer>
          <DropdownContainer>
            <Dropdown list={subspeciesDropdownList} onSelected={dropdownSubspeciesSelected} />
          </DropdownContainer>
          <DropdownContainer>
            <Dropdown list={weightsDropdownList} onSelected={dropdownWeightsSelected} />
          </DropdownContainer>


          <Price>{getTotalprice()}$</Price>

          <OrderButton onClick={orderButtonClickHandler}>To order</OrderButton>

        </MainContentContainer>
      </HeadContainer>
      <ProductDetailDescriptionContainer>
        <ProductDetailDescription delivery={delivery} description={description} storageConditions={storageConditions} />
      </ProductDetailDescriptionContainer>
      <RecommendationsTitle>Recommendations</RecommendationsTitle>
      <RecommendationsContainer>
        {recommendedProducts.map(p => (<ProductCard key={p.id} product={p} addToCart={addRecomendationProductToCart} goToDetail={goToRecomendationProductDetail} />))}
      </RecommendationsContainer>

    </Container>
  )
}
