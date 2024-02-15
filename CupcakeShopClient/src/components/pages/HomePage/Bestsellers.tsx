import { useEffect, useRef, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks"
import { Product } from "../../../store/types";
import { getBestsellers } from "../../../store/reducers/bestsellerReducer";
import styled from "styled-components";
import ArrowImg from "../../../assets/images/SliderArrow.png";
import { SliderSection } from "./SliderSection";



const Container = styled.div`
	box-sizing: border-box;
	margin: 2rem 0 0 0; 
	padding: 0;
    overflow-y: hidden;
`;

const Slider = styled.div`

    font-family: sans-serif;
	scroll-snap-type: x mandatory;	
	-webkit-overflow-scrolling: touch;
	overflow-x: scroll;
    display: flex;
    width: 100%;
    
    @media (min-width: 958px) {
        display: flex;
    }
`;



const DesktopNavigation = styled.div`
    display: none;
    justify-content: end;
    gap: 2rem;
    margin: 0 8% 1rem 0;
    .blocked{
        cursor: default;
        background-color: var(--color-light);
    }
    @media (min-width: 958px) {
        display: flex;
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



const PairWrapper = styled.div`
    display: flex;
    flex-direction: column;

    @media (min-width: 958px) {
        flex-direction: row;        
    }

`;


export const Bestsellers = () => {
    const bestsellerStore = useAppSelector(state => state.bestsellerStore);
    const [nextItemId, setNextItemId] = useState<string | undefined>(undefined);
    const [previousItemId, setPreviousItemId] = useState<string | undefined>(undefined);
    const [isLastItem, setIsLastItem] = useState<boolean>(false);
    const [isFirstItem, setIsFirstItem] = useState<boolean>(false);

    const scrollToNextItem = () => {
        if (nextItemId) {
            sliderRef.current?.querySelector('[id="' + nextItemId + '"]')?.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" })
        }
    }

    const scrollToPreviousItem = () => {
        if (previousItemId) {
            sliderRef.current?.querySelector('[id="' + previousItemId + '"]')?.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" })
        }
    }

    const sliderRef = useRef<HTMLDivElement>(null);


    const addToCart = (id: number) => {
        /*to do*/
        console.log(`add ${id} to cart`);
    }

    const goToDetail = (id: number) => {
        /*to do*/
        console.log(`go to ${id} detail`);
    }

    const handleScroll = () => {
        if (sliderRef.current) {
            let sliderWidth = sliderRef.current.clientWidth;

            const nextElements: Element[] = [];

            Array.from(sliderRef.current.children).forEach((el) => {
                Array.from(el.children).forEach((childEl) => {
                    if (childEl.getBoundingClientRect().left >= sliderWidth) {
                        nextElements.push(childEl);
                    }
                });
            });


            const previousElements: Element[] = [];

            Array.from(sliderRef.current.children).forEach((el) => {
                Array.from(el.children).forEach((childEl) => {
                    if (childEl.getBoundingClientRect().left < 0) {
                        previousElements.push(childEl);
                    }
                });
            });


            if (nextElements.length === 0) {
                setIsLastItem(true);
            }

            if ((nextElements.length > 0) && isLastItem) {
                setIsLastItem(false);
            }

            if (previousElements.length === 0) {
                setIsFirstItem(true);
            }

            if ((previousElements.length > 0) && isFirstItem) {
                setIsFirstItem(false);
            }

            if (nextElements[0]?.id !== nextItemId) {
                setNextItemId(nextElements[0]?.id);
            }

            if (previousElements[previousElements.length - 1]?.id !== nextItemId) {
                setPreviousItemId(previousElements[previousElements.length - 1]?.id);
            }
        }
    };


    const dispatch = useAppDispatch();

    useEffect(() => {
        dispatch(getBestsellers())
    },
        [dispatch]);

    useEffect(() => {
        handleScroll();
    },
        [bestsellerStore]);


    return (

        <Container>
            <DesktopNavigation>
                <SlideNavigationElement onClick={scrollToPreviousItem} className={isFirstItem ? "blocked" : ""}>
                    <LeftArrow src={ArrowImg} alt="Left arrow" />
                </SlideNavigationElement>
                <SlideNavigationElement onClick={scrollToNextItem} className={isLastItem ? "blocked" : ""}>
                    <RightArrow src={ArrowImg} alt="Right arrow" />
                </SlideNavigationElement>

            </DesktopNavigation>
            <Slider ref={sliderRef} onScroll={handleScroll}>
                {bestsellerStore.list.map((b, index, elements) => {

                    if (index % 2 !== 0) {
                        return null;
                    }

                    return (
                        <PairWrapper key={index}>
                            <SliderSection  product={b} addToCart={addToCart} goToDetail={goToDetail}/>
                            {elements[index + 1] && (
                                <SliderSection product={elements[index + 1]} addToCart={addToCart} goToDetail={goToDetail}/>
                            )}
                        </PairWrapper>)
                })}
            </Slider>
        </Container>

    )
}
