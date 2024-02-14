import styled from "styled-components";
import GirlImg from "../../../assets/images/cookingGirl.png";


const Container = styled.div`
    padding: 0 5rem;
    display:flex;
    flex-direction: column;
    @media (min-width: 1200px) {
        flex-direction: row;
    }
`;
const TextWrapper = styled.div`
    margin: 2rem 1rem 0 10%;
    @media (min-width: 1200px) {
        margin: 4rem 10% 0 10%;
    }
`;
const Title = styled.div`
    font-size: var(--text-size-large);
    text-transform: uppercase;
    margin-bottom: 3rem;
    text-align: center;
    @media (min-width: 1200px) {
        text-align: left;
    }
`;
const Description = styled.div`
    font-size: var(--text-size-medium);
    p{
        margin-bottom: 2rem;
    }
`;
const StyledImg = styled.img`
    margin: 2rem auto 0 auto;
    width: 100%;
    height: min-content;
    max-width: 499px;
    max-height: 749px;
    @media (min-width: 1200px) {
        margin: -10% 0 0 0;
    }
`;

export const AboutUs = () => {
    return (
        <Container>

            <StyledImg src={GirlImg} alt="Photo" />
            <TextWrapper>
                <Title>Lorem ipsum dolor sit.</Title>
                <Description>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing.</p>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Animi, aliquid eius quia ipsum repudiandae voluptas odit, eaque ad, consectetur a ea iure assumenda magni. Numquam dignissimos libero culpa blanditiis fuga.</p>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Deserunt quod voluptates dolores quaerat amet odio.</p>
                </Description>
            </TextWrapper>

        </Container>
    )
}
