import { Banner } from "./Banner";
import { ShortCatalog } from "./ShortCatalog";
import styled from "styled-components";
import BackgroundWaveImg from "../../../assets/images/backgroundWave.png"
import { WhyWe } from "./WhyWe";
import { DeliveryInfo } from "./DeliveryInfo";
import { AboutUs } from "./AboutUs";
import { Questions } from "./Questions";
import { Bestsellers } from "./Bestsellers";

const Title = styled.div`
font-family: var(--font-family-bold);
font-size: var(--text-size-large);
text-align: center;
margin-top: 2rem;
@media (min-width: 572px) {
  font-size: var(--text-size-huge-mobil);
  margin-top: 5rem;
}
@media (min-width: 958px) {
  font-size: var(--text-size-huge);
}
`;

const BackgroundWaveContainer = styled.div`
    background-image: url(${BackgroundWaveImg});
    background-repeat: no-repeat;
    background-size: cover;
    background-position-x: center;
    margin-top: 3rem;

    @media (min-width: 958px) {
      background-size: 100% 100%;
    }
  `;


export const HomePage = () => {

  return (
    <main>
      <Banner />
      <ShortCatalog />
      <Title id="bestsellers">Bestsellers</Title>
      <Bestsellers />
      <BackgroundWaveContainer>
        <Title style={{ marginTop: "-3rem" }} id="whyWe">Why we?</Title>
        <WhyWe />

        <Title id="delivery">Delivery and payment</Title>
        <DeliveryInfo />
      </BackgroundWaveContainer>

      <Title id="about_us">About us</Title>
      <AboutUs />

      <Title id="questions">Popular questions</Title>
      <Questions />
    </main>
  )
}
