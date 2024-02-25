import styled from "styled-components";
import RemoveOrderItemImg from "../../assets/images/removeOrderItem.png";
import { useEffect, useState } from "react";
import CakeImg from "../../assets/images/cupcake.png";
import { useNavigate } from "react-router-dom";
import { Order } from "../../store/types";
import { useAppDispatch, useAppSelector } from "../../hooks";
import { removeProductFromCart } from "../../store/reducers/cartReducer";

const Container = styled.main`
  margin: 0 5%;
  padding-right: 8%;
  
  @media (min-width: 1200px) {
    padding-right: 0;
  }

  .showThanksPopup{
    display: block;
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
  font-size: var(--text-size-extra-large);
  font-family: var(--font-family-black);
  text-align: center;
  margin: 2rem 0 2rem 2rem;
  @media (min-width: 767px) {
    font-size: var(--text-size-huge-mobil);
  }
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
  grid-template-columns: 1fr 90px 30px 20px;
  .price{
    text-align: right;
    padding-right: 7px;
  }
`;
const StyledLabel = styled.label`
    display: flex;
    align-items: center;
`;
const AddresContainer = styled.div`
  display: none;
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
  .showAddres{
    display: grid;
  }
  
`;
const Button = styled.div`
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


const ThanksPopup = styled.div`
  max-width: 600px;
  max-height: 70%;
  background-color: var(--color-light);
  box-shadow: 1px 2px 5px 1px gray;
  position: fixed;
  z-index: 2;
  left: 50%;
  top: 40%;
  transform: translate(-50%, -40%);
  display: none; 
  overflow-y: scroll;
  scroll-snap-type: y mandatory;	
  -webkit-overflow-scrolling: touch;
  width: 90%;
  @media (min-width: 767px) {
    width: 80%;
    left: 50%;
  }
`;
const ThanksContainer = styled.div`
  text-align: center;
  .popupBtn{
    width: 200px;
    margin: 2rem auto 2rem auto;
  };
  .popupTitle{
    font-size: var(--text-size-extra-large);
    margin-bottom: 0;
  }
`;
const CakeImgElement = styled.img`
  margin-top: -2rem;
  margin-left: 2rem;
`;


export const OrderPage = () => {
  const [thanksPopupIsShowed, setThanksPopupIsShowed] = useState<boolean>(false);
  const [order, setOrder] = useState<Order>({ deliveryMethod: "pickup", paymentMethod: "method1" });
  const cartReducer = useAppSelector(state => state.cartReducer);
  const dispatch = useAppDispatch();

  const navigate = useNavigate();
  const redirectToHome = () => {
    window.scrollTo(0, 0);
    navigate("/");
  }

  const orderButtonClick = () => {
    setThanksPopupIsShowed(true);
  }

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  const changeHandler = (element: React.ChangeEvent<HTMLInputElement> | React.ChangeEvent<HTMLTextAreaElement>) => {

    const name: string = element.currentTarget.name;
    const value: string = element.currentTarget.value;
    setOrder({ ...order, [name]: value })
  }

  const removeCartItem = (id?: number) => {
    if (id) {
      dispatch(removeProductFromCart(id));
    }
  }

  const getTotalPrice:() => string = () => {
    let totalPrice:number =0;
    cartReducer.cart.map(c=>
      totalPrice+=c.product.price  
      +(c.additionDecoration?.price || 0)
      +(c.additionSubspecies?.price||0)
      +(c.additionWeight?.price||0)) 
      return totalPrice+" $"
  }


  return (
    <Container>
      {cartReducer.cart.length === 0 && (<Title>Cart is empty</Title>)}
      {cartReducer.cart.length > 0 && (<>
        <Title>Making an order</Title>
        <ContentContainer>
          <StyledDiv className="mainContent">
            <SubTitle>Contacts</SubTitle>
            <StyledInput name="name" placeholder="Name" onChange={(e) => changeHandler(e)} />
            <StyledInput name="phone" placeholder="Phone" onChange={(e) => changeHandler(e)} />
            <StyledInput name="email" placeholder="Email" onChange={(e) => changeHandler(e)} />
            <Date name="date" type="date" onChange={(e) => changeHandler(e)} />
            <SubTitle>Delivery method</SubTitle>
            <StyledDiv>
              <StyledLabel>
                <RadioButton name="deliveryMethod" type="radio" value="pickup"
                  checked={order.deliveryMethod === "pickup"}
                  onChange={(e) => changeHandler(e)} />
                Pickup
              </StyledLabel>
              <StyledLabel>
                <RadioButton name="deliveryMethod" type="radio" value="courier"
                  checked={order.deliveryMethod === "courier"}
                  onChange={(e) => changeHandler(e)} />
                Delivery by courier
              </StyledLabel>
            </StyledDiv>
            <AddresContainer className={order.deliveryMethod === "courier" ? "showAddres" : ""}>
              <StyledInput name="city" className="city" placeholder="City" onChange={(e) => changeHandler(e)} />
              <StyledInput name="street" placeholder="Street" onChange={(e) => changeHandler(e)} />
              <StyledInput name="house" placeholder="House" onChange={(e) => changeHandler(e)} />
              <StyledInput name="entrance" placeholder="Entrance" onChange={(e) => changeHandler(e)} />
              <StyledInput name="building" placeholder="Building" onChange={(e) => changeHandler(e)} />
              <StyledInput name="apartment" placeholder="Apartment" onChange={(e) => changeHandler(e)} />
              <StyledInput name="floor" placeholder="Floor" />
            </AddresContainer>
            <SubTitle>Payment method</SubTitle>
            <StyledDiv>
              <StyledLabel>
                <RadioButton name="paymentMethod" type="radio" value="method1"
                  checked={order.paymentMethod === "method1"}
                  onChange={(e) => changeHandler(e)} />
                Payment method 1
              </StyledLabel>
              <StyledLabel>
                <RadioButton name="paymentMethod" type="radio" value="method2"
                  checked={order.paymentMethod === "method2"}
                  onChange={(e) => changeHandler(e)} />
                Payment method 2
              </StyledLabel>
            </StyledDiv>
            <StyledTextarea name="commentary" placeholder="Commentary" onChange={(e) => changeHandler(e)} />
            <PriceContainer>
              <SubTitle>Total to be paid:</SubTitle>
              <Price>{getTotalPrice()}</Price>
            </PriceContainer>
            <Button onClick={orderButtonClick}>Сonfirm the order</Button>
          </StyledDiv>
          <ControlPanel>
            <ControlPanelTitle>Your order:</ControlPanelTitle>
            {cartReducer.cart.map(ci => (
              <ProductItemContainer key={ci.id}>
                <div>{ci.product.name}</div>
                <div className="price">{ci.product.price}</div>
                <div>$</div>
                <RemoveItemImg onClick={() => removeCartItem(ci.id)} src={RemoveOrderItemImg}></RemoveItemImg>
              </ProductItemContainer>
            ))}
          </ControlPanel>
        </ContentContainer>
      </>)}
      <ThanksPopup className={thanksPopupIsShowed ? "showThanksPopup" : ""}>
        <ThanksContainer>
          <Title className="popupTitle">Thanks for your order!</Title>
          <CakeImgElement src={CakeImg} alt="cake" />
          <Button onClick={redirectToHome} className="popupBtn">Ok</Button>
        </ThanksContainer>
      </ThanksPopup>
    </Container>
  )
}


