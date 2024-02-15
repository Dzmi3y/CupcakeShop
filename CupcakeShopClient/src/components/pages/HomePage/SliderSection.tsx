import React from 'react'
import styled from 'styled-components';
import { ReactComponent as CartImg } from "../../../assets/images/cart.svg";
import { Product } from '../../../store/types';

const Section = styled.section`
    display: flex;
    flex-direction: column;
    align-items: center;
	padding: 1rem 0 0 0;
	min-width: 393px;
	scroll-snap-align: end;
	position: relative;
    min-width: 100vw;
    text-align: center;
    
    @media (min-width: 958px) {
        padding: 1rem;
        min-width: 393px;
    }
`;


const StyledImg = styled.img`
    width: 393px;
    height: 393px;
`;
const Cart = styled(CartImg)`
    cursor: pointer;
`;


const TitleContainer = styled.div`
    margin-top: 1rem;
    display: flex;
    justify-content: space-between;
    width: 393px;
`;
const Title = styled.div`
    font-size: var(--font-size-large);
`;
const Description = styled.div`
    font-size: var(--font-size-medium);
    text-align: left;
    width: 393px;
    `;


const ImgContainer = styled.div`
    position: relative;
    &:hover {
        .overlay{
            display: flex;
        }        
    } 
`;
const OverlayElement = styled.div`
 position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.5); 
    cursor: pointer;
    align-items: center;
    justify-content: center;
    display: none;
    `;

const Details = styled.div`  
    border-radius: 10px;
    font-size: var(--font-size-large);
    text-transform: uppercase;
    background-color: var(--color-pale-yellow);
    display: flex;
    align-items: center;
    justify-content: center;
    width: 276px;
    height: 67px;
   
`;

type SliderSectionProps={ 
    product: Product, 
    addToCart: (id: number) => void, 
    goToDetail: (id: number) => void 
};


export const SliderSection: React.FC<SliderSectionProps> = ({product,addToCart,goToDetail}) => {
    return (
        <Section id={product.id + ""}>
            <ImgContainer onClick={() => { goToDetail(product.id) }}>
                <StyledImg src={product.imgUrl} alt={product.name} />
                <OverlayElement className="overlay" >
                    <Details>Details</Details>
                </OverlayElement>
            </ImgContainer>
            <TitleContainer>
                <Title>{product.name}</Title>
                <Cart onClick={() => { addToCart(product.id) }} />
            </TitleContainer>
            <Description>{product.price}$ / {product.weight}{product.unitOfMeasurement}</Description>
        </Section>
    )
}
