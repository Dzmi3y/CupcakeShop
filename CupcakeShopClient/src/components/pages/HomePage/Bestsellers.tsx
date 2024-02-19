import { useEffect, useRef, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks"
import { getBestsellers } from "../../../store/reducers/bestsellerReducer";
import styled from "styled-components";
import ArrowImg from "../../../assets/images/SliderArrow.png";
import { ProductCard } from "../../common/ProductCard";

const Container = styled.section`
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

    &::-webkit-scrollbar {           
         width: 0 !important;
    }
    
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

const MobilNavigation = styled.div`
    display: flex;
    justify-content: center;
    margin: 2rem auto 3rem auto;
    .blocked{
        cursor: default;
        background-color: var(--color-light);
    }
    @media (min-width: 958px) {
        display: none;
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
const DotsContainer = styled.div`
    display: flex;
    justify-content: center;
    gap: 5px;
    min-width: 210px;
    margin: auto 1rem auto 1rem;
    .selected{
            background-color: var(--color-dark);
    }
`;

const Dot = styled.div`
    height: 11px;
    width: 11px;
    border-radius: 50%;
    background-color: var(--color-pale-yellow);   
`;



const PairWrapper = styled.div`
    display: flex;
    flex-direction: column;
    .productCard{
    min-width: 100vw;
    @media (min-width: 958px) {
        min-width: 393px;
    }
    }

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
    const [totalItems, setTotalItems] = useState<number>(0);
    const [currentItem, setCurrentItem] = useState<number>(0);

    const [dotsArray, setDotsArray] = useState<JSX.Element[]>([]);

    const sliderRef = useRef<HTMLDivElement>(null);

    const scrollToNextItem = () => {
        if (nextItemId) {
            let parentDiv: HTMLElement | null | undefined = sliderRef.current;
            let targetElement: HTMLElement | null | undefined = sliderRef.current?.querySelector('[id="' + nextItemId + '"]');
            if (parentDiv && targetElement) {
                parentDiv.scroll({ left: targetElement.offsetLeft, behavior: 'smooth' })
            }
        }
    }


    const scrollToPreviousItem = () => {
        if (previousItemId) {
            let parentDiv: HTMLElement | null | undefined = sliderRef.current;
            let targetElement: HTMLElement | null | undefined = sliderRef.current?.querySelector('[id="' + previousItemId + '"]');
            if (parentDiv && targetElement) {
                parentDiv.scroll({ left: targetElement.offsetLeft - parentDiv.offsetWidth + targetElement.offsetWidth, behavior: 'smooth' });
            }
        }
    }


    const addToCart = (id: number) => {
        /*to do*/
        console.log(`add ${id} to cart`);
    }

    const goToDetail = (id: number) => {
        /*to do*/
        console.log(`go to ${id} detail`);
    }


    const getSlideNavArraysForDesktop = (sliderWidth: number) => {
        const nextElements: Element[] = [];
        const previousElements: Element[] = [];

        if (sliderRef.current) {
            Array.from(sliderRef.current.children).forEach((el) => {
                Array.from(el.children).forEach((childEl) => {
                    if (Math.round(childEl.getBoundingClientRect().left) >= sliderWidth) {
                        nextElements.push(childEl);
                    }
                });
            });

            Array.from(sliderRef.current.children).forEach((el) => {
                Array.from(el.children).forEach((childEl) => {
                    if (Math.round(childEl.getBoundingClientRect().left) < 0) {
                        previousElements.push(childEl);
                    }
                });
            });
        }
        return { nextElements, previousElements };
    }

    const getSlideNavArraysForMobil = (sliderWidth: number) => {
        const nextElements: Element[] = [];
        const previousElements: Element[] = [];

        if (sliderRef.current) {
            Array.from(sliderRef.current.children).forEach((el) => {
                if (Math.round(el.getBoundingClientRect().left) >= sliderWidth) {
                    nextElements.push(el);
                }
            });

            Array.from(sliderRef.current.children).forEach((el) => {
                if (Math.round(el.getBoundingClientRect().left) < 0) {
                    previousElements.push(el);
                }
            });
        }
        return { nextElements, previousElements };
    }

    const handleScroll = () => {
        if (sliderRef.current) {
            let sliderWidth = sliderRef.current.clientWidth;

            const { nextElements, previousElements }: { nextElements: Element[]; previousElements: Element[]; } =
                (window.screen.width >= 958)
                    ? getSlideNavArraysForDesktop(sliderWidth)
                    : getSlideNavArraysForMobil(sliderWidth);

            const total: number = nextElements.length + previousElements.length + 1;


            if (totalItems !== total) {
                setTotalItems(total);
            }

            if (currentItem !== previousElements.length) {
                setCurrentItem(previousElements.length);
            }


            let dots = Array.from({ length: total }, (_, i) => (
                <Dot key={i} className={i === previousElements.length ? "selected" : ""} />
            ));

            setDotsArray(dots);

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

            if (previousElements[previousElements.length - 1]?.id !== previousItemId) {
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
        const handleLoad = () => {
            handleScroll();
        };

        window.addEventListener("load", handleLoad);

        return () => {
            window.removeEventListener("load", handleLoad);
        };
    },
        []);


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
                        <PairWrapper key={index} id={"pair_" + index}>
                            <ProductCard product={b} addToCart={addToCart} goToDetail={goToDetail} />
                            {elements[index + 1] && (
                                <ProductCard product={elements[index + 1]} addToCart={addToCart} goToDetail={goToDetail} />
                            )}
                        </PairWrapper>)
                })}
            </Slider>
            <MobilNavigation>
                <SlideNavigationElement onClick={scrollToPreviousItem} className={isFirstItem ? "blocked" : ""}>
                    <LeftArrow src={ArrowImg} alt="Left arrow" />
                </SlideNavigationElement>
                <DotsContainer>
                    {dotsArray}

                </DotsContainer>
                <SlideNavigationElement onClick={scrollToNextItem} className={isLastItem ? "blocked" : ""}>
                    <RightArrow src={ArrowImg} alt="Right arrow" />
                </SlideNavigationElement>
            </MobilNavigation>
        </Container>

    )
}
