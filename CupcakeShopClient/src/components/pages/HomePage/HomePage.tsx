import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks"
import { Bestseller } from "../../../store/types";
import { getBestsellers } from "../../../store/reducers/bestsellerReducer";
import { Banner } from "./Banner";
import { ShortCatalog } from "./ShortCatalog";
import styled from "styled-components";
import BackgroundWaveImg from "../../../assets/images/backgroundWave.png"
import { WhyWe } from "./WhyWe";


export const HomePage = () => {

  const bestsellerStore = useAppSelector(state => state.bestsellerStore);

  const dispatch = useAppDispatch();


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
    height: 1900px;
    margin-top: 3rem;

    @media (min-width: 958px) {
      background-size:contain;  
    }
  `;

  useEffect(() => {
    dispatch(getBestsellers())
  },
    [dispatch]);

  return (
    <>
      <Banner />
      <ShortCatalog />
      <Title id="bestsellers">Bestsellers</Title>
      <div>
        {bestsellerStore.list.map(b => (<div key={b.id}><h1>{b.name}</h1> <b>{b.typeName}</b></div>))}
      </div>
      <BackgroundWaveContainer>
        <Title style={{marginTop:"-3rem"}} id="whyWe">Why we?</Title>
        <WhyWe/>

        <Title id="delivery">Delivery and payment</Title>

      </BackgroundWaveContainer>

      <Title id="about_us">About us</Title>

    </>
  )
}
