import styled from 'styled-components';
import CupcakeImg from '../../../assets/images/cupcakeBanner.png';
import TelegramImg from '../../../assets/images/telegramDark.png';
import FacebookImg from '../../../assets/images/facebookDark.png';
import InstagramImg from '../../../assets/images/instagramDark.png';
import Grann from '../../../assets/images/GRANN.png';

const Container = styled.div`
    padding: 5rem 0;
`;
const TitleContainer = styled.div`
    text-align:center;
    margin-left:0;

    @media (min-width: 767px) {
        text-align:center;

    }

    @media (min-width: 1189px) {
        margin-left: 0;
        text-align: right;
        display: grid;
        grid-template-columns: 1100px auto;
        grid-template-rows: auto auto;
    }
`;
const TitleImg = styled.img`
    grid-row-start: 1;
    justify-self: right;
    grid-column-start: 1;
    width: 220px;
    @media (min-width: 767px) {
        width: auto;
    }
    `;

const SubTitle = styled.div`
    font-family: var(--font-family-light);
    font-size: var(--text-size-large);
    grid-row-start: 2;
    grid-column-start: 1;
    margin-top: 1rem;
    @media (min-width: 1189px) {
        margin-right: -1rem;   
    }
`;

const IconImg = styled.img`
    cursor: pointer
`;

const BannerContainer = styled.div`
    display: flex;
`;

const BannerImg = styled.img`
    margin-top: 1rem;
    margin-left: -15rem;
    width: 470px;

    @media (min-width: 393px) {
        margin-left: -10rem;
    }

    @media (min-width: 767px) {
        margin-top: 1rem;
        margin-left: -15rem;
        width: auto;
    }

    @media (min-width: 1189px) {
        margin-left: 0;
        margin-top: -5rem;
    }
`;

const IconContainer = styled.div`
    display: grid;
    grid-template-rows: repeat(3, 1fr); 
    gap: 0.5rem;
    height: 100px;
    margin: auto 2rem 3rem auto;

    @media (min-width: 767px) {       
        margin: auto 5rem 8rem auto;
    }

`;


export const Banner = () => {
    return (
        <Container>
            <TitleContainer>
                <TitleImg src={Grann} />
                <SubTitle>author's desserts</SubTitle>
            </TitleContainer>
            <BannerContainer>
                <BannerImg src={CupcakeImg} alt='CupcakeBanner' />
                <IconContainer>
                    <IconImg src={TelegramImg} alt='Telegram' />
                    <IconImg src={FacebookImg} alt='Facebook' />
                    <IconImg src={InstagramImg} alt='Instagram' />
                </IconContainer>
            </BannerContainer>

        </Container>
    )
}
