import { Link } from 'react-router-dom';
import styled from 'styled-components'
import PizzaImg from '../../../assets/images/pizzaFilter.png'
import CookiesImg from '../../../assets/images/cookiesFilter.png'
import ChouxImg from '../../../assets/images/chouxFilter.png';
import CakeImg from '../../../assets/images/cakeFilter.png';



const Container = styled.div`
  display: grid;
  grid-template-rows: 1fr 1fr 1fr 1fr;
  gap: 1rem;
  @media (min-width: 884px) {
    grid-template-columns: 1fr 1fr;
    grid-template-rows:  1fr 1fr;
  }
`;
const Title = styled.div`
  font-size: var(--text-size-large);
  background-color: var(--color-pale-yellow);
  border-radius: 10px;
  width: 300px;
  height: 67px;
  text-transform: uppercase;
  margin: auto;
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1;
  position: relative;

  @media (min-width: 884px) {
    width: 276px;
    height: 67px;
  }
`;
const StyledImg = styled.img`
  width:80% ;
  margin-left: 10%;
  @media (min-width: 1332px) {
    width:auto ;
    margin-left: 0px;
  }
`;
const ContainerItem = styled.div`
  justify-self: center;
  .text{
    margin-top: -2rem;
    width: 256px;
    height: 47px;
    @media (min-width: 884px) {
      width: 276px;
      height: 67px;
    }
    @media (min-width: 1024px) {
      margin-top: -3rem;
  }
  }
`;
const StyledLink = styled(Link)`
  text-decoration: none; 
  color: var(--color-dark);
`;


export const ShortCatalog = () => {
  return (
    <section>
      <div style={{marginBottom:"2rem"}}>
        <StyledLink to="/catalog">
          <Title className='text'>to the catalog</Title>
        </StyledLink>
      </div>
      <Container>
        <ContainerItem>
          <StyledLink to="/catalog">
            <StyledImg src={CakeImg} alt='Cake' />
            <Title className='text'>cake</Title>
          </StyledLink>
        </ContainerItem>
        <ContainerItem>
          <StyledLink to="/catalog">
            <StyledImg src={ChouxImg} alt='Choux' />
            <Title className='text'>choux</Title>
          </StyledLink>
        </ContainerItem>
        <ContainerItem>
          <StyledLink to="/catalog">
            <StyledImg src={CookiesImg} alt='Cookies' />
            <Title className='text'>cookies</Title>
          </StyledLink>
        </ContainerItem>
        <ContainerItem>
          <StyledLink to="/catalog">
            <StyledImg src={PizzaImg} alt='Pizza' />
            <Title className='text'>pizza</Title>
          </StyledLink>
        </ContainerItem>
      </Container>
    </section>
  )
}