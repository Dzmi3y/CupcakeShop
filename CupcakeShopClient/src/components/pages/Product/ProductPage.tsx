import { useNavigate, useSearchParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getAdditionalParams, getDetailProductInfo, getRecommendedProducts } from "../../../store/reducers/detailProductReducer";
import { useEffect } from "react";
import styled from "styled-components";
import { BreadCrumbs, BreadCrumbsItem } from "../../common/BreadCrumbs";
import { ProductImgSlider } from "./ProductImgSlider";
import { Dropdown, DropdownItem } from "../../common/Dropdown";
import { ProductDetailDescription } from "./ProductDetailDescription";

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

const BreadCrumbsContainer = styled.div`
  margin: 2rem 0 0 2%;
  @media (min-width: 958px) {
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

  const testList: DropdownItem[] = [
    { id: 1, text: "test 1" },
    { id: 2, text: "test 2" },
    { id: 3, text: "test 3" },
    { id: 4, text: "test 4" }
  ]


  
  useEffect(() => {
    dispatch(getDetailProductInfo(Number(id)));
    dispatch(getAdditionalParams(Number(id)));
    dispatch(getRecommendedProducts({ id: Number(id), count: 4 }));
  }, [dispatch]);

  let breadCrumbsList: BreadCrumbsItem[] = [];
  if (detailProductStore.productInfo) {
    breadCrumbsList = [
      { title: "Home", link: "/" },
      { title: "Catalog", link: "/catalog" },
      { title: detailProductStore.productInfo.name, link: null }
    ];
  }

  const OrderButtonClickHandler = () => {
    /*To Do*/
    console.log("order button clicked")
  }

  const dropdown1Selected=(id:number)=>{
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

      <ProductDetailDescription />


    </Container>
  )
}
