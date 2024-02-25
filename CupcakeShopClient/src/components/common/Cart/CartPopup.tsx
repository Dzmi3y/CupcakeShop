import React from 'react'
import styled from 'styled-components';
import { useAppDispatch, useAppSelector } from '../../../hooks';
import CloseCartImg from '../../../assets/images/CloseCatr.png';
import { removeProductFromCart } from '../../../store/reducers/cartReducer';
import { CartItem } from '../../../store/types';
import { useNavigate } from 'react-router-dom';

const Container = styled.div`
    width: 100%;
    padding: 2rem 3rem;
`;
const ContentContainer = styled.div`
    display: flex;
    justify-content: space-between;

    align-items: center;
    flex-direction: column;
    @media (min-width: 1410px) {
        flex-direction: row;
    }
`;
const ControlPanel = styled.div`
    display: flex;
    flex-direction: column;
    background-color: var(--color-pale-yellow);
    border-radius: 10px;
    max-width: 320px;
    width: 100%;
    height: 150px;
    padding: 1rem 1rem;
    align-items: center;
    margin-bottom: 2rem;
`;
const ControlText = styled.div`
    font-family: var(--font-family-bold);
    font-size: var(--text-size-medium);
    display: flex;
    gap: 1rem;
    margin-top: 1rem;
    margin-bottom: 1rem;
`;
const OrderButton = styled.button`
    font-family: var(--font-family-light);
    font-size: var(--text-size-large);
    color: var(--color-light);
    background-color: var(--color-dark);
    text-transform: uppercase;
    max-width: 287px;
    width: 100%;
    height: 67px;
    border-radius: 10px;
`;

const ProductList = styled.div`
    display: flex;
    flex-direction: column;
    gap: 2rem;
    margin-bottom: 2rem;
`;
const TitleContainer = styled.div`
    display: flex;
    justify-content: space-between;    
    margin-bottom: 3rem;
`;
const Title = styled.div`
    font-family: var(--font-family-light);
    font-size: var(--text-size-large);
`;
const CloseImg = styled.img`
    cursor: pointer;
`;
const RemoveImg = styled.img`
    cursor: pointer;
    width: 20px;
    height: 20px;
`;
const ProductContainer = styled.div`
    display: flex;
    gap: 4rem;
    align-items: center;
    flex-direction: column;
    @media (min-width: 958px) {
        flex-direction: row;
    }
`;
const ProductImg = styled.img`
    max-width: 286px;
    width: 100%;
`;
const ProductName = styled.div`
    font-family: var(--font-family-light);
    font-size: var(--text-size-large);
    display: flex;
    justify-content: space-between;
    margin-bottom: 2rem;
`;
const DescriptionContainer = styled.div``;
const DescriptionText = styled.div`
    font-family: var(--font-family-light);
    font-size: var(--text-size-medium);
    display: grid;
    grid-template-columns: 130px 1fr;
    margin-bottom: 1rem;
    text-align: left;
`;

const CartIsEmptyText = styled.div`
    font-size: var(--text-size-large);
    text-align: center;
    margin: 6rem 0;
`;

export const CartPopup: React.FC<{ onClose: () => void }> = ({ onClose }) => {
    const cartReducer = useAppSelector(state => state.cartReducer);
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    let totalPrice = 0;

    const cartIsEmpty = cartReducer.cart.length === 0;

    cartReducer.cart.map((p) => {
        totalPrice += p.product.price
            + (p.additionDecoration?.price || 0)
            + (p.additionSubspecies?.price || 0)
            + (p.additionWeight?.price || 0)
    });

    const removeCartItem = (id?: number) => {
        if (id) {
            dispatch(removeProductFromCart(id));
        }
    }

    const getWeight: (cartItem: CartItem) => string = (cartItem: CartItem) => {
        if (cartItem.additionWeight?.unitOfMeasurement === cartItem.product.unitOfMeasurement) {
            return cartItem.product.weight + (cartItem.additionWeight?.weight || 0) + cartItem.product.unitOfMeasurement
        }

        if (cartItem.product.unitOfMeasurement === "kg") {
            return cartItem.product.weight + (cartItem.additionWeight?.weight || 0) / 1000 + cartItem.product.unitOfMeasurement
        }

        if (cartItem.product.unitOfMeasurement === "g") {
            return cartItem.product.weight + ((cartItem.additionWeight?.weight || 0) * 1000) + cartItem.product.unitOfMeasurement
        }

        return "";
    }

    const goToOrderPage = ()=>{
        onClose();
        navigate("/order");

    }


    return (
        <Container>
            <TitleContainer>
                <Title>Cart</Title>
                <CloseImg src={CloseCartImg} alt='close' onClick={onClose} />
            </TitleContainer>
            {cartIsEmpty && (<CartIsEmptyText>The cart is still empty</CartIsEmptyText>)}
            {!cartIsEmpty && (<ContentContainer>
                <ProductList>
                    {cartReducer.cart.map((ci, i) => (
                        <ProductContainer key={i}>
                            <ProductImg src={ci.product.imgUrl} alt={ci.product.name} />

                            <DescriptionContainer>
                                <ProductName>
                                    <span>{ci.product.name}</span>
                                    <RemoveImg src={CloseCartImg} alt='close' onClick={() => removeCartItem(ci.id)} />
                                </ProductName>
                                <DescriptionText>
                                    <span>Subspecies:</span>
                                    <span>{ci.additionSubspecies?.name || "Default subspecies"}</span>
                                </DescriptionText>
                                <DescriptionText>
                                    <span>Decoration:</span>
                                    <span>{ci.additionDecoration?.name || "Without decoration"}</span>
                                </DescriptionText>
                                <DescriptionText>
                                    <span>Weight:</span>
                                    <span>
                                        {getWeight(ci)}
                                    </span>
                                </DescriptionText>
                            </DescriptionContainer>
                        </ProductContainer>
                    ))}
                </ProductList>
                <ControlPanel>
                    <ControlText>
                        <span>Total price:</span>
                        <span>{totalPrice}$</span></ControlText>
                    <OrderButton onClick={goToOrderPage}>Place an order</OrderButton>
                </ControlPanel>
            </ContentContainer>)}
        </Container>
    )
}
