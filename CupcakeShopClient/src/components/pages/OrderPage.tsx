import styled from "styled-components";
import CalendarImg from "../../assets/images/calendar.png";
import RemoveOrderItemImg from "../../assets/images/removeOrderItem.png"
import { useEffect } from "react";

const Container = styled.main`
  margin: 0 5%;
  padding-right: 8%;
  
  @media (min-width: 1200px) {
    padding-right: 0;
  }

  .mainContent{
    order:2;
    @media (min-width: 1200px) {
      padding: 0;
      order: 1;
    };
  }
`;
const ContentContainer = styled.main` 
  display: flex;
  flex-direction: column;
  align-items: center;

  @media (min-width: 1200px) {
    align-items: start;
    flex-direction: row;
    justify-content: space-between;
  }
`;

const ControlPanel = styled.div`
    order: 1;
    display: flex;
    flex-direction: column;
    background-color: var(--color-pale-yellow);
    border-radius: 10px;
    max-width: 500px;
    width: 100%;
    height: 150px;
    padding: 1rem 1rem;
    align-items: center;
    margin-bottom: 2rem;
    margin-top: 1rem;
    margin-left: 2rem;
    font-size: var(--text-size-small);
    @media (min-width: 1200px) {
      order: 2;
      margin-top: 72px;
    }
`;

const ControlPanelTitle = styled.div`
  font-size: var(--text-size-medium);
  text-align: left;
  width: 100%;
  padding: 1rem 0 1rem 0;
`;

const Title = styled.div`
  font-size: var(--text-size-huge-mobil);
  font-family: var(--font-family-black);
  text-align: center;
  margin: 2rem 0;
  @media (min-width: 1200px) {
    font-size: var(--text-size-huge);
  }

`;
const SubTitle = styled.div`
  font-size: var(--text-size-large);
  text-align: left;
  margin: 1rem 0;
`;
const Price = styled.div`
  font-size: var(--text-size-large);
  font-family: var(--font-family-bold);
`;
const PriceContainer = styled.div`
  max-width: 500px;
  width: 100%;
  display: flex;
  justify-content: space-between;
  padding: 1rem 1rem 0 1rem;
  margin-top: 1rem;
  border-top: 2px solid var(--color-pale-yellow);
`;
const RadioButton = styled.input`
  -webkit-appearance: none;
  -moz-appearance: none;
  appearance: none;
  display: inline-block;
  width: 20px;
  height: 20px;
  background-clip: content-box;
  border: 6px solid var(--color-pale-yellow);
  background-color: var(--color-pale-yellow);
  margin: 0 1rem 0 0;
  border-radius: 50%;
  &:checked{
    background-color: var(--color-dark); 
  };
`;
const StyledInput = styled.input`
  background-color: var(--color-pale-yellow);
  color: var(--color-dark);
  font-size: var(--text-size-medium);
  border-radius: 10px;
  border: 0;
  max-width: 500px;
  height: 60px;
  padding: 0 1rem; 
  width: 100%;
`;
const Date = styled.input`
  background-color: var(--color-pale-yellow);
  color: var(--color-dark);
  font-size: var(--text-size-medium);
  border-radius: 10px;
  background-color: var(--color-pale-yellow);
  max-width: 500px;
  width: 100%;
 
  border: 0;
  height: 60px;
  padding: 0 1rem;
`;
const RemoveItemImg = styled.img`
  cursor: pointer;
  margin: auto 0;
`;
const DateImg = styled.img``;
const StyledTextarea = styled.textarea`
  background-color: var(--color-pale-yellow);
  color: var(--color-dark);
  font-size: var(--text-size-medium);
  border-radius: 10px;
  padding: 1rem;
  height: 100px;
  border: 0;
  resize: none;
  max-width: 500px;
  width: 100%;
`;
const ProductItemContainer = styled.div`
  display: grid;
  width: 100%;
  grid-template-columns: 1fr 60px 20px;
`;
const StyledLabel = styled.label`
    display: flex;
    align-items: center;
`;
const AddresContainer = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 3rem;
  max-width: 500px;
  width: 100%;
  .city{
    grid-column-start: 1;
    grid-column-end: 3;
  };
`;
const StyledDiv = styled.div`
  display: flex;
  flex-direction:column;
  gap: 1rem;
  max-width: 500px;
  width: 100%;
  
`;
const OrderButton = styled.div`
    font-family: var(--font-family-light);
    font-size: var(--text-size-large);
    color: var(--color-dark);
    background-color: var(--color-pale-yellow);
    text-transform: uppercase;
    max-width: 500px;
    width: 100%;
    height: 67px;
    border-radius: 10px;
    border: 0;
    margin-bottom: 4rem;
    padding: 0 1rem;
    display: flex;
    justify-content: center;
    align-items: center;
    box-shadow: 0.5px 0.5px 1px 1px gray;
    cursor: pointer;
    &:hover{
      box-shadow: 0.2px 0.2px 1px 1px gray;
    }
    &:active{
      box-shadow: 0px 0px 0px 0px gray;
    }

`;



export const OrderPage = () => {


  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  return (
    <Container>
      <Title>Making an order</Title>
      <ContentContainer>
        <StyledDiv className="mainContent">
          <SubTitle>Contacts</SubTitle>
          <StyledInput placeholder="Name" />
          <StyledInput placeholder="Phone" />
          <StyledInput placeholder="Email" />
          <Date placeholder="Date" />
          <SubTitle>Delivery method</SubTitle>
          <StyledDiv>
            <StyledLabel>
              <RadioButton name="delivery" type="radio" value="pickup" />
              Pickup
            </StyledLabel>
            <StyledLabel>
              <RadioButton name="delivery" type="radio" value="courier" />
              Delivery by courier
            </StyledLabel>
          </StyledDiv>
          <AddresContainer className="showAddres">
            <StyledInput className="city" placeholder="City" />
            <StyledInput placeholder="Street" />
            <StyledInput placeholder="House" />
            <StyledInput placeholder="Entrance" />
            <StyledInput placeholder="Building" />
            <StyledInput placeholder="Apartment" />
            <StyledInput placeholder="Floor" />
          </AddresContainer>
          <SubTitle>Payment method</SubTitle>
          <StyledDiv>
            <StyledLabel>
              <RadioButton name="payment" type="radio" value="method1" />
              Payment method 1
            </StyledLabel>
            <StyledLabel>
              <RadioButton name="payment" type="radio" value="method2" />
              Payment method 2
            </StyledLabel>
          </StyledDiv>
          <StyledTextarea placeholder="Commentary" />
          <PriceContainer>
            <SubTitle>Total to be paid:</SubTitle>
            <Price>11$</Price>
          </PriceContainer>
          <OrderButton>Сonfirm the order</OrderButton>
        </StyledDiv>
        <ControlPanel>
          <ControlPanelTitle>Your order:</ControlPanelTitle>
          <ProductItemContainer>
            <div>Name</div>
            <div>10$</div>
            <RemoveItemImg src={RemoveOrderItemImg}></RemoveItemImg>
          </ProductItemContainer>
        </ControlPanel>
      </ContentContainer>
    </Container>
  )
}
