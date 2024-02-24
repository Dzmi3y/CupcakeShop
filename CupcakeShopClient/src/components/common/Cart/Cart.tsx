import React, { useEffect, useRef, useState } from 'react'
import { CartPopup } from './CartPopup'
import styled from 'styled-components';
import { ReactComponent as CartImg } from "../../../assets/images/cart.svg";
import { AdditionWeight, AdditionalProductParameter, CartItem, Product } from '../../../store/types';
import { addProductToCart } from '../../../store/reducers/cartReducer';
import { useAppDispatch } from '../../../hooks';

const Container = styled.div`
        .showCartModal{
        display: flex;
    }
`;

const CartIcon = styled(CartImg)`
    cursor: pointer;
`;

const CartModal = styled.div`
  max-width: 1236px;
  /* min-height: 500px; */
  max-height: 70%;
  background-color: var(--color-light);
  box-shadow: 1px 2px 5px 1px gray;
  position: fixed;
  z-index: 2;
  left: 48%;
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

const OrderButton = styled.button`
  background-color: var(--color-dark);
  color: var(--color-light);
  font-size: var(--text-size-large);
  font-family: var(--font-family-light);
  width: 287px;
  height: 68px;
  border-radius: 10px;
`;

export type AdditionalParams={
    currentDecoration?: AdditionalProductParameter,
    currentSubspecies?: AdditionalProductParameter,
    currentAdditionalWeight?: AdditionWeight,
}

export const Cart: React.FC<{ product?: Product | null, isOrderButton?: boolean, additionalParams?:AdditionalParams }> = ({ product, isOrderButton = false,additionalParams }) => {
    const [cartModalIsOpen, setCartModalIsOpen] = useState(false);
    const cartModalRef = useRef<HTMLDivElement>(null);
    const dispatch = useAppDispatch();

    const cartClickHandler = () => {
            if (product) {
                const cartIten: CartItem = { 
                    product: product,      
                    additionDecoration: additionalParams?.currentDecoration?.id !== 0 ? additionalParams?.currentDecoration : undefined,
                    additionSubspecies: additionalParams?.currentSubspecies?.id !== 0 ? additionalParams?.currentSubspecies : undefined,
                    additionWeight: additionalParams?.currentAdditionalWeight?.id !== 0 ? additionalParams?.currentAdditionalWeight : undefined,
                }
                dispatch(addProductToCart(cartIten));
            }
            setCartModalIsOpen(!cartModalIsOpen);
        }

        useEffect(() => {
            const handleClickOutside = (event: MouseEvent) => {
                if (cartModalRef.current && !cartModalRef.current.contains(event.target as Node)) {
                    setCartModalIsOpen(false);
                }
            };

            document.addEventListener('mousedown', handleClickOutside);
            return () => {
                document.removeEventListener('mousedown', handleClickOutside);
            };
        }, []);
        return (
            <Container>
                {isOrderButton
                    ? (<OrderButton onClick={cartClickHandler}>Add to cart</OrderButton>)
                    : (<CartIcon onClick={cartClickHandler} />)
                }
                <CartModal className={cartModalIsOpen ? "showCartModal" : ""} ref={cartModalRef}>
                    <CartPopup onClose={() => setCartModalIsOpen(false)} />
                </CartModal>
            </Container>
        )
    }
