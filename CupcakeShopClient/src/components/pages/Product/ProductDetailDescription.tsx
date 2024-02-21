import React, { useState } from 'react'
import styled from 'styled-components';

const Container = styled.div`
  margin: 10px 0;
`;
const DecorContainer = styled.div`
  display: flex;
  justify-content: space-between;
  height: 4px;
  background-color: var(--color-pale-yellow);
  margin-top: 10px;
  .hide{
    background-color: var(--color-pale-yellow);
  }
`;
const DecorItem = styled.div`
  background-color: var(--color-dark);
  height: 4px;
  width: 76px;
  border-radius: 4px;
  margin: 0 10px;
`;
const Info = styled.div`
  min-height: 200px;
  margin: 20px 10px;
  text-transform: capitalize;
`;
const Title = styled.div`
  font-size: var(--text-size-small);
  cursor: pointer;
  margin: 0 10px;
  @media (min-width: 767px) {
    font-size: var(--text-size-medium);
  }
`;
const TitleContainer = styled.div`
  display: flex;
  justify-content: space-between;
  
`;

export const ProductDetailDescription: React.FC<{ description: string, storageConditions: string, delivery: string }> =
  ({ description, storageConditions, delivery }) => {

    const [selectedItem, setSelectedItem] = useState<number>(0);
    const infoList: string[] = [description, storageConditions, delivery];

    return (
      <Container>
        <TitleContainer>
          <Title onClick={() => setSelectedItem(0)} >Description</Title>
          <Title onClick={() => setSelectedItem(1)}>Storage conditions</Title>
          <Title onClick={() => setSelectedItem(2)} >Delivery</Title>
        </TitleContainer>
        <DecorContainer>
          <DecorItem className={selectedItem !== 0 ? "hide" : ""} />
          <DecorItem className={selectedItem !== 1 ? "hide" : ""} />
          <DecorItem className={selectedItem !== 2 ? "hide" : ""} />
        </DecorContainer>
        <Info>{infoList[selectedItem]}</Info>
      </Container>
    )
  }
