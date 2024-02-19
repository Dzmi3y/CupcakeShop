import styled from 'styled-components';
import { HashLink } from 'react-router-hash-link';
import React, { useState } from 'react';
import { ReactComponent as LogoImg } from "../../../assets/images/logo.svg";
import { ReactComponent as CartImg } from "../../../assets/images/cart.svg";
import { ReactComponent as BurgerImg } from "../../../assets/images/burger.svg";
import MobilMenu from './MobilMenu';

const Wrapper = styled.nav`
    display: grid;
    align-items: center;   
    padding: 0 1rem;
    box-shadow: var(--shadow);
    margin: 0;
    grid-template-columns:  3fr 7fr 1fr 2fr;

    @media (min-width: 589px) {
        grid-template-columns:  2fr 8fr 1fr 1fr;
        padding: 0 2rem;
    }
    @media (min-width: 767px) {
        grid-template-columns:  1fr 2fr 1fr 1fr 1fr 1fr;
        padding: 1rem 2rem;
    }

    @media (min-width: 958px) {
        grid-template-columns:  2fr 3fr 2fr 2fr 2fr 1fr;
        padding: 1rem 4rem;
    }

    @media (min-width: 1024px) {
        grid-template-columns:  2fr 3fr 5fr 2fr 2fr 1fr;
    }

    @media (min-width: 1243px) {
        grid-template-columns:  2fr 3fr 10fr 2fr 2fr 1fr;
    }
`;

const HeaderDesktopLink = styled(HashLink)`
    display: none;
    @media (min-width: 767px) {
        display: inline;
        font-family: var(--font-family-light);
        color: var(--color-dark);
        font-size: var(--text-size-small);
        text-decoration: none; 
        text-transform: uppercase;
        place-self: center;  
    }
`;


const LogoWrapper = styled.div`
    grid-column-start: 2;
    text-align: center;
    @media (min-width: 767px) {
        grid-column-start: 3;  
    }
`;

const ImgLink = styled(HashLink)`
    text-transform: uppercase;
    place-self: center;

`;

const HeaderMobilDiv = styled.div`
   
   @media (min-width: 767px) {
        display:none;
    };
`;


const Logo = styled(LogoImg)`
    transform: scale(0.8);
    
    @media (min-width: 767px) {
        transform: scale(1);
        margin: 0 0 0 45px;
    };
`;

const Burger = styled(BurgerImg)`
    cursor: pointer;
`;


export const Header = () => {
    const [modalOpen, setModalOpen] = useState(false);
    const toggleModal = () => {
        setModalOpen(!modalOpen);
    };
    const closeModal = () => {
        setModalOpen(false);
    };
    return (
        <header>
            <Wrapper>
                <HeaderDesktopLink to='/#bestsellers' >bestsellers</HeaderDesktopLink>
                <HeaderDesktopLink to='/catalog' >catalog</HeaderDesktopLink>
                <LogoWrapper>
                    <ImgLink className='logo' to='/' >
                        <Logo />
                    </ImgLink>
                </LogoWrapper>
                <HeaderDesktopLink to='/#delivery' >delivery</HeaderDesktopLink>
                <HeaderDesktopLink to='/#about_us' >about us</HeaderDesktopLink>
                <HeaderMobilDiv>
                    <Burger onClick={toggleModal} />
                </HeaderMobilDiv>
                <ImgLink to='/order' >
                    <CartImg />
                </ImgLink>
            </Wrapper>
            <MobilMenu isOpen={modalOpen} onClose={closeModal} />

        </header>
    )
}
