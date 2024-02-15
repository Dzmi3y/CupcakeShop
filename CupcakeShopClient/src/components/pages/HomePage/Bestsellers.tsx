import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks"
import { Product } from "../../../store/types";
import { getBestsellers } from "../../../store/reducers/bestsellerReducer";
import styled from "styled-components";
import { ReactComponent as CartImg } from "../../../assets/images/cart.svg";
import ArrowImg from "../../../assets/images/SliderArrow.png";



const Container = styled.div`
	box-sizing: border-box;
	margin: 2rem 0 0 0; 
	padding: 0;
    overflow-y: hidden;
`;

const Slider = styled.div`
    font-family: sans-serif;
	scroll-snap-type: x mandatory;	
	display: flex;
	-webkit-overflow-scrolling: touch;
	overflow-x: scroll;
`;

const Section = styled.section`
	padding: 1rem;
    width: 100px;
	min-width: 393px;
	scroll-snap-align: end;
	position: relative;
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
`;
const Title = styled.div`
    font-size: var(--font-size-large);
`;
const Description = styled.div`
    font-size: var(--font-size-medium);`;

const SlideNavigationContainer = styled.div`
    display: flex;
    justify-content: end;
    gap: 2rem;
    margin: 0 8% 1rem 0;
    .blocked{
        cursor: default;
        background-color: var(--color-light);
    }
    
`;
const SlideNavigationElement = styled.div`
    cursor: pointer;
    border: 2px solid var(--color-dark);
    background-color: var(--color-pale-yellow);
    border-radius: 22px;
    width: 76px;
    height: 27px;
    text-align: center;


`;
const RightArrow = styled.img`
    transform: rotate(180deg);
    margin-top: 11px;
`;
const LeftArrow = styled.img`
    margin-top: 11px;
`;


export const Bestsellers = () => {
    const bestsellerStore = useAppSelector(state => state.bestsellerStore);

    const dispatch = useAppDispatch();

    useEffect(() => {
        dispatch(getBestsellers())
    },
        [dispatch]);


    return (

        <Container>
            <SlideNavigationContainer>
                <SlideNavigationElement className="blocked">
                    <LeftArrow src={ArrowImg} alt="Left arrow" />
                </SlideNavigationElement>
                <SlideNavigationElement>
                    <RightArrow src={ArrowImg} alt="Right arrow" />
                </SlideNavigationElement>

            </SlideNavigationContainer>
            <Slider>
                {bestsellerStore.list.map(b => (
                    <Section key={b.id}>
                        <StyledImg src={b.imgUrl} alt={b.name} />
                        <TitleContainer>
                            <Title>{b.name}</Title>
                            <Cart />
                        </TitleContainer>
                        <Description>{b.price}$ / {b.weight}{b.unitOfMeasurement}</Description>
                    </Section>))}
            </Slider>
        </Container>

    )
}
