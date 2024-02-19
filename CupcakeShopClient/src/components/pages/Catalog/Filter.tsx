import styled from 'styled-components'

const Container = styled.div`
    display:flex;
    margin-left: 5%;
    gap: 1rem;
    .selected{
        background-color: var(--color-dark);
        color: var(--color-light);
    }
`;
const FilterItem = styled.div`
    padding: 0 1rem ;
    display: flex;
    background-color: var(--color-light);
    font-size: var(--text-size-medium);
    font-family: var(--font-family-light);
    color: var(--color-dark);
    height: 42px;
    cursor: pointer;
    border: 2px solid var(--color-dark);
    border-radius: 100px;
    justify-content: center;
    align-items: center;
    
    
`;


export const Filter = () => {



    return (
        <Container>
            <FilterItem className='selected'>Cakes</FilterItem>
            <FilterItem>Cookies</FilterItem>
        </Container>
    )
}
