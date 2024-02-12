import styled from 'styled-components';
import React from 'react';
import { Link } from 'react-router-dom';
import { HashLink } from 'react-router-hash-link';
import { ReactComponent as LogoImg } from "../assets/images/logo.svg";
import { ReactComponent as CartImg } from "../assets/images/cart.svg";


const Wrapper = styled.div`
    display: grid;
    align-items: center;
    
    padding: 2rem 10rem;
    box-shadow: var(--shadow);
    margin: 0;
    grid-template-columns:  2fr 2fr 3fr 2fr 2fr 1fr;

    @media (min-width: 1024px) {
        grid-template-columns:  2fr 2fr 5fr 2fr 2fr 1fr;
    }

    @media (min-width: 1243px) {
        grid-template-columns:  2fr 2fr 10fr 2fr 2fr 1fr;
    }
    

`;

const HeaderLink = styled(HashLink)`
    font-family: var(--font-family-light);
    color: var(--color-dark);
    font-size: var(--text-size-small);
    text-decoration: none; 
    text-transform: uppercase;
    place-self: center;
`;

const Logo = styled(LogoImg)`
`
const Cart = styled(CartImg)`
`
    ;

export const Header = () => {
    return (
        <Wrapper>

                <HeaderLink to='/#bestsellers' >bestsellers</HeaderLink>
                <HeaderLink to='/catalog' >catalog</HeaderLink>
            
            <HeaderLink to='/' >
                <Logo />
            </HeaderLink>
           
                <HeaderLink to='/#delivery' >delivery</HeaderLink>
                <HeaderLink to='/#about_us' >about us</HeaderLink>
                <HeaderLink to='/order' >
                    <Cart />
                </HeaderLink>
            
        </Wrapper>
    )
}
