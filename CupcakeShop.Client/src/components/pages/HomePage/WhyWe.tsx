import styled from "styled-components"
import CupcakeImg from "../../../assets/images/bigCupcake.png"

const Container = styled.section`
    margin: 0 5rem;
    display: flex;
    flex-direction: column;
    @media (min-width: 958px) {
        flex-direction: row;
    }

`;
const Cupcake = styled.img`
    width: 100%;
    margin: auto;
    order: 2;
    @media (min-width: 767px) {
        width: 605px;
        height: 629px;
    }
    @media (min-width: 958px) {
        order: 1;
        width: 305px;
        height: 329px;
    }
    @media (min-width: 1200px) {
        width: 605px;
        height: 629px;
    }
`;
const List = styled.div`
    margin-top: 3rem;
    text-align: center;
    list-style-type: none;
    order: 1;
    @media (min-width: 958px) {
        text-align: left;
        margin-left: 5%;
        list-style-type: disc;
        order: 2;
    }
    @media (min-width: 1576px) {
        margin-left: 10%;
    }
`;
const ListItem = styled.div`
    font-size: var(--text-size-medium);
    text-transform: uppercase;
    margin-bottom: 1rem;
    &::marker{
        color: var(--color-light);
        font-size: 2rem;
    }
    @media (min-width: 1200px) {
        font-size: var(--text-size-large);
     
    }
`;
const ItemDescription = styled.div`
    font-size: var(--text-size-medium);
    margin-bottom: 2rem;
    @media (min-width: 1200px) {
        font-size: var(--text-size-small);
     
    }
`;


export const WhyWe = () => {
    return (
        <Container>
            <Cupcake src={CupcakeImg} alt="cupcake" />
            <List>
                <ListItem>Item 1. Lorem ipsum dolor sit amet.</ListItem>
                <ItemDescription>Description 1. Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatibus neque doloribus quae ad maiores autem perferendis voluptatem ratione pariatur hic!</ItemDescription>
                <ListItem>Item 2. Lorem ipsum, dolor sit amet consectetur adipisicing elit.</ListItem>
                <ItemDescription>Description 2. Lorem ipsum dolor sit amet consectetur adipisicing elit. Adipisci, itaque minus? Earum illum omnis vero sit rem, exercitationem, pariatur ducimus debitis provident laboriosam mollitia inventore, quod sunt libero assumenda unde!</ItemDescription>
                <ListItem>Item 3. Lorem, ipsum dolor.</ListItem>
                <ItemDescription>Description 3. Lorem ipsum dolor sit amet consectetur adipisicing elit. Perspiciatis, esse aut voluptatum quas adipisci eius.</ItemDescription>
            </List>
        </Container>
    )
}
