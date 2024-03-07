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
import { AdditionWeight, AdditionalProductParameter, CartItem, Product } from "../../../store/types";
import cartReducer, { addProductToCart } from "../../../store/reducers/cartReducer";
import { Cart } from "../../common/Cart/Cart";

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
 width: 100%;
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
  font-size: var(--text-size-large);
  font-family: var(--font-family-light);
  margin-bottom: 2rem;
  @media (min-width: 958px) {
    font-size: var(--text-size-extra-large);
  }
`;

const Price = styled.div`
  font-size: var(--text-size-large);
  font-family: var(--font-family-light);
  grid-column-start: 1;
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

    const listOfshortDetails: Array<string> = JSON.parse(detailProductStore.productInfo?.listOfshortDetails || "[]");
    const imgUrls: Array<string> = JSON.parse(detailProductStore.productInfo?.imgUrlsJson || "[]");


  let breadCrumbsList: BreadCrumbsItem[] = [];
  if (detailProductStore.productInfo) {
    breadCrumbsList = [
      { title: "Home", link: "/" },
      { title: "Catalog", link: "/catalog" },
      { title: detailProductStore.productInfo.name, link: null }
    ];
  }

  const goToRecomendationProductDetail = (id: string) => {
    navigate(`/catalog/product?id=${id}`);
  }

  const dropdownDecorationsSelected = (id: string) => {
    const decoration = decorations.find(d => d.id === id);
    if (decoration) {
      setCurrentDecoration(decoration);
    }
  }

  const dropdownSubspeciesSelected = (id: string) => {
    const selectedSubspecies = subspecies.find(s => s.id === id);
    if (selectedSubspecies) {
      setCurrentSubspecies(selectedSubspecies);
    }
  }

  const dropdownWeightsSelected = (id: string) => {
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
      dispatch(getDetailProductInfo(id || ""));
      dispatch(getAdditionalParams(id || ""));
    dispatch(getRecommendedProducts({
      id: id || "",
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
                  <ProductImgSlider urls={imgUrls} />
        </ImgSliderContainer>
        <MainContentContainer>

          <Title>{detailProductStore.productInfo?.name}</Title>

          <ShortDescriptionList>
                {listOfshortDetails.map((d, i) => (
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

          <Cart isOrderButton={true}
            product={detailProductStore?.productInfo}
            additionalParams={{
              currentDecoration: currentDecoration,
              currentSubspecies: currentSubspecies,
              currentAdditionalWeight: currentAdditionalWeight
            }} />

        </MainContentContainer>
      </HeadContainer>
      <ProductDetailDescriptionContainer>
        <ProductDetailDescription delivery={delivery} description={description} storageConditions={storageConditions} />
      </ProductDetailDescriptionContainer>
      <RecommendationsTitle>Recommendations</RecommendationsTitle>
      <RecommendationsContainer>
        {recommendedProducts.map(p => (<ProductCard key={p.id} product={p} goToDetail={goToRecomendationProductDetail} />))}
      </RecommendationsContainer>

    </Container>
  )
}
