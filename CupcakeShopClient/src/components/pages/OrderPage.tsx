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
  
  &.incorrect{
    box-shadow: 0px 0px 5px 0.1px red;
  }
    
  
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

type Fields = "name" | "phone" | "city" | "street" | "house" | "entrance" | "apartment" | "floor";


export const OrderPage = () => {
  const [thanksPopupIsShowed, setThanksPopupIsShowed] = useState<boolean>(false);
  const [order, setOrder] = useState<Order>({ deliveryMethod: "pickup", paymentMethod: "method1" });
  const [incorrectFields, setIncorrectFields] = useState<string[]>([]);
  let incorrectList: string[] = [...incorrectFields];
  const requiredFields: Fields[] = ["name", "phone"];
  const requiredAddresFields: Fields[] = ["city", "street", "house", "entrance", "apartment", "floor"];

  const cartReducer = useAppSelector(state => state.cartReducer);
  const dispatch = useAppDispatch();

  const navigate = useNavigate();
  const redirectToHome = () => {
    window.scrollTo(0, 0);
    navigate("/");
  }

  const orderButtonClick = () => {
    validateAll();
    console.log(incorrectList)
    //setThanksPopupIsShowed(true);
  }



  const validateAll = () => {

    const requiredsList: string[] = [...requiredFields, ...requiredAddresFields];
    requiredsList.map(r => validateByName(r));
    setIncorrectFields(incorrectList);
  }


  const validateByName = (name: Fields | string, updatedOrder?: Order) => {

    const _order = updatedOrder || order;

    const _name = name as Fields;
    const isAddress: boolean = !!requiredAddresFields.find(ra => ra === name);
    const addressIsRequired: boolean = _order.deliveryMethod === "courier";
    const requiredsList: string[] = addressIsRequired ? [...requiredFields, ...requiredAddresFields] : [...requiredFields];
    const isRequired: boolean = !!requiredsList.find(rf => rf === name);
    const itWasIncorrect: boolean = !!incorrectList.find(ic => ic === name);
    const isCorrectNow: boolean = !!_order[_name];

    if (isRequired && !itWasIncorrect && !isCorrectNow) {
      incorrectList.push(name);

    }

    if (isRequired && itWasIncorrect && isCorrectNow) {
      incorrectList = incorrectList.filter(ic => ic !== name)

    }

    if (!addressIsRequired && itWasIncorrect && isAddress) {
      incorrectList = incorrectList.filter(ic => ic !== name)
    }

  }

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);


  const changeHandler = (element: React.ChangeEvent<HTMLInputElement> | React.ChangeEvent<HTMLTextAreaElement>) => {


    const name: string = element.target.name;
    const value: string = element.target.value;
    const updatedOrder = { ...order, [name]: value };
    validateByName(name,updatedOrder);
    setOrder(updatedOrder)
    setIncorrectFields(incorrectList);

  }

  const removeCartItem = (id?: number) => {
    if (id) {
      dispatch(removeProductFromCart(id));
    }
  }

  const getTotalPrice: () => string = () => {
    let totalPrice: number = 0;
    cartReducer.cart.map(c =>
      totalPrice += c.product.price
      + (c.additionDecoration?.price || 0)
      + (c.additionSubspecies?.price || 0)
      + (c.additionWeight?.price || 0))
    return totalPrice + " $"
  }

  const getClass = (fieldName: string) => {
    return (incorrectFields.find(f => f === fieldName)) ? "incorrect" : "";
  }


  return (
    <Container>
      {cartReducer.cart.length === 0 && (<Title>Cart is empty</Title>)}
      {cartReducer.cart.length > 0 && (<>
        <Title>Making an order</Title>
        <ContentContainer>
          <StyledDiv className="mainContent">
            <SubTitle>Contacts</SubTitle>
            <StyledInput name="name" className={getClass("name")} placeholder="Name" onChange={(e) => changeHandler(e)} />
            <StyledInput name="phone" className={getClass("phone")} type="tel" placeholder="Phone" onChange={(e) => changeHandler(e)} />
            <StyledInput name="email" className={getClass("email")} type="email" placeholder="Email" onChange={(e) => changeHandler(e)} />
            <Date name="date" className={getClass("date")} type="date" onChange={(e) => changeHandler(e)} />
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
              <StyledInput name="city" className={"city " + getClass("city")} placeholder="City" onChange={(e) => changeHandler(e)} />
              <StyledInput name="street" className={getClass("street")} placeholder="Street" onChange={(e) => changeHandler(e)} />
              <StyledInput name="house" className={getClass("house")} placeholder="House" onChange={(e) => changeHandler(e)} />
              <StyledInput name="entrance" className={getClass("entrance")} placeholder="Entrance" onChange={(e) => changeHandler(e)} />
              <StyledInput name="building" placeholder="Building" onChange={(e) => changeHandler(e)} />
              <StyledInput name="apartment" className={getClass("apartment")} placeholder="Apartment" onChange={(e) => changeHandler(e)} />
              <StyledInput name="floor" className={getClass("floor")} placeholder="Floor" />
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


