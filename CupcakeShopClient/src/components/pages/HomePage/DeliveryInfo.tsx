import styled from "styled-components";
import DeliveryImg from "../../../assets/images/bikeDelivery.png";
import CashImg from "../../../assets/images/cashOnDelivery.png";
import BoxImg from "../../../assets/images/packageBox.png";

const Container = styled.section`
    display: flex;
    justify-content: center;
    margin-top: 5rem;
    flex-direction: column;
    margin-bottom: 15rem;

    .midleElement {
            border-left: 0;
            border-right: 0;
            border-top: 2px solid var(--color-beige);
            border-bottom: 2px solid var(--color-beige);
            padding: 1rem 0 1rem 0;
        }

    @media (min-width: 958px) {
        flex-direction: row;
        .midleElement {
            padding: 0 1rem 0 1rem;
            border-left: 2px solid var(--color-beige);
            border-right: 2px solid var(--color-beige);
            border-top: 0;
            border-bottom: 0;
        }
    }
`;
const ContainerItem = styled.div`
    width: 60%;
    text-align: center;
    margin: 2rem auto 0 auto;
    @media (min-width: 958px) {
        margin: 0;
        width: 288px;
    }

`;
const ImgWrapper = styled.div`
    height: 87px;
`;
const StyledImg = styled.img``;
const Title = styled.div`
    font-size: var(--text-size-large);
    text-transform: uppercase;
    margin-top: 1rem;
`;
const Description = styled.div`
    font-size: var(--text-size-medium);
    margin-top: 1rem;
`;


export const DeliveryInfo = () => {
    return (
        <Container>
            <ContainerItem>
                <ImgWrapper>
                    <StyledImg src={BoxImg} alt="Pickup" />
                </ImgWrapper>
                <Title>Pickup</Title>
                <Description>Lorem ipsum dolor sit amet consectetur.</Description>
            </ContainerItem>
            <ContainerItem className="midleElement">
                <ImgWrapper>
                    <StyledImg src={DeliveryImg} alt="Delivery" />
                </ImgWrapper>
                <Title>Delivery</Title>
                <Description>Lorem ipsum dolor sit amet, consectetur adipisicing.</Description>
            </ContainerItem>
            <ContainerItem>
                <ImgWrapper>
                    <StyledImg src={CashImg} alt="Prepayment" />
                </ImgWrapper>
                <Title>Prepayment</Title>
                <Description>Lorem ipsum dolor sit.</Description>
            </ContainerItem>
        </Container>
    )
}
