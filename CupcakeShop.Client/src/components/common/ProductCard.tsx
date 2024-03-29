import React from 'react'
import styled from 'styled-components';
import { ReactComponent as CartImg } from "../../assets/images/cart.svg";
import { Product } from '../../store/types';
import { Cart } from './Cart/Cart';

const Container = styled.section`
    display: flex;
    flex-direction: column;
    align-items: center;
	padding: 1rem 0 0 0;
    width: 100%;
    max-width: 393px;
	scroll-snap-align: end;
	position: relative;
    text-align: center;

    @media (min-width: 958px) {
        padding: 1rem;
    }
`;

const StyledImg = styled.img`
    width: 100%;
    height: 100%;
    max-width: 393px;
    max-height: 393px;
`;



const TitleContainer = styled.div`
    margin-top: 1rem;
    display: flex;
    justify-content: space-between;
    width: 90%;
    max-width: 393px;
    @media (min-width: 958px) {
        width: 100%;
    }
`;
const Title = styled.div`
    font-size: var(--font-size-large);
`;
const Description = styled.div`
    font-size: var(--font-size-medium);
    text-align: left;
    width: 90%;
    max-width: 393px;
    @media (min-width: 958px) {
        width: 100%;
    }
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

type ProductCardProps = {
    product: Product,
    goToDetail: (id: string) => void
};

export const ProductCard: React.FC<ProductCardProps> = ({ product, goToDetail }) => {
    return (
        <Container className='productCard' id={product.id + ""}>
            <ImgContainer onClick={() => { goToDetail(product.id) }}>
                <StyledImg src={product.imgUrl} alt={product.name} />
                <OverlayElement className="overlay" >
                    <Details>Details</Details>
                </OverlayElement>
            </ImgContainer>
                <TitleContainer>
                    <Title>{product.name}</Title>
                    <Cart product={product} />
                </TitleContainer>
                <Description>{product.price}$ / {product.weight}{product.unitOfMeasurement}</Description>   
        </Container>
    )
}
