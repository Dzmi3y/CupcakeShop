import React from 'react'
import styled from 'styled-components';
import { useAppDispatch, useAppSelector } from '../../hooks';
import CloseCartImg from '../../assets/images/CloseCatr.png';
import { removeProductFromCart } from '../../store/reducers/cartReducer';

const Container = styled.div`
    width: 100%;
    padding: 2rem 3rem;
`;
const ContentContainer = styled.div`
    display: flex;
    justify-content: space-between;
`;
const ControlPanel = styled.div`
    display: flex;
    flex-direction: column;
    background-color: var(--color-pale-yellow);
    border-radius: 10px;
    width: 320px;
    height: 150px;
    padding: 1rem 1rem;
    align-items: center;
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
    width: 287px;
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
    gap: 4rem
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
`;

const CartIsEmptyText= styled.div`
    font-size: var(--text-size-large);
    text-align: center;
    margin: 6rem 0;
`;

export const Cart: React.FC<{ onClose: () => void }> = ({ onClose }) => {
    const cartReducer = useAppSelector(state => state.cartReducer);
    const dispatch = useAppDispatch();
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


    return (
        <Container>
            <TitleContainer>
                <Title>Cart</Title>
                <CloseImg src={CloseCartImg} alt='close' onClick={onClose} />
            </TitleContainer>
            {cartIsEmpty && (<CartIsEmptyText>The cart is still empty</CartIsEmptyText>)}
            {!cartIsEmpty && ( <ContentContainer>
                <ProductList>
                    {cartReducer.cart.map((p) => (
                        <ProductContainer key={p.product.id}>
                            <ProductImg src={p.product.imgUrl} alt={p.product.name} />

                            <DescriptionContainer>
                                <ProductName>
                                    <span>{p.product.name}</span>
                                    <RemoveImg src={CloseCartImg} alt='close' onClick={() => removeCartItem(p.id)} />
                                </ProductName>
                                <DescriptionText>
                                    <span>Subspecies:</span>
                                    <span>{p.additionSubspecies?.name || "Default subspecies"}</span>
                                </DescriptionText>
                                <DescriptionText>
                                    <span>Decoration:</span>
                                    <span>{p.additionDecoration?.name || "Without decoration"}</span>
                                </DescriptionText>
                                <DescriptionText>
                                    <span>Weight:</span>
                                    <span>
                                        {p.product.weight + (p.additionWeight?.weight || 0)}
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
                    <OrderButton>Place an order</OrderButton>
                </ControlPanel>
            </ContentContainer>)}
        </Container>
    )
}
