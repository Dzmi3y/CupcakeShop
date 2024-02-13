import React from 'react'
import styled from 'styled-components'
import { ReactComponent as InstagramImg } from "../assets/images/_Instagram.svg";
import { ReactComponent as WhatsappImg } from "../assets/images/whatsapp.svg";
import { ReactComponent as TelegramImg } from "../assets/images/telegram.svg";
import LogoImg from "../assets/images/logoGrannFooter.png"

const Wrapper = styled.div`
  width: 100%;
  margin: 0;
  padding: 1.5rem 0 2rem;
  text-align: center;
  background-color: var(--color-dark);
  font-size: var(--font-size-medium);
  color: var(--color-light);

  .wraperItem{
    margin-bottom: 1rem;
  }

  @media (min-width: 767px) {
    display: flex;
    text-align: left;
    justify-content: space-around;
    .leftContainer{
      order: 1;
    }
    .logo{
      order: 2;
    }
    .rightContainer{
      order: 3;
    }
  }
`;
const Logo = styled.img`
  width: 100px; 
  height: 100px; 
  object-fit: cover;
  
`;


export const Footer = () => {

  return (
    <Wrapper>
      <Logo className='wraperItem logo' src={LogoImg} alt='logo' />
      <div className='leftContainer'>
        <div className='wraperItem'>City A, Street 1</div>
        <div className='wraperItem'>Email: email@gmail.com</div>
        <div className='wraperItem'>Phone: +123 (45) 67890</div>
      </div>
      <div className='rightContainer'>
        <div className='wraperItem'>
          <InstagramImg style={{ cursor: "pointer" }} />
          <WhatsappImg style={{ cursor: "pointer", margin: "0 1rem 0 1rem" }} />
          <TelegramImg style={{ cursor: "pointer" }} />
        </div>
        <div className='wraperItem' style={{ cursor: "pointer" }}>Privacy policy</div>
        <div className='wraperItem' style={{ cursor: "pointer" }}>Offer agreement</div>
      </div>
    </Wrapper>
  )
}
