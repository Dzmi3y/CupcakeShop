import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../../../hooks"
import { Bestseller } from "../../../store/types";
import { getBestsellers } from "../../../store/reducers/bestsellerReducer";
import { Banner } from "./Banner";


export const HomePage = () => {

  const bestsellerStore = useAppSelector(state => state.bestsellerStore);
 
  const dispatch = useAppDispatch();



  useEffect(() => {
    dispatch(getBestsellers())
  },
    [dispatch]);

  return (
    <>
      <Banner/>

      <div id="bestsellers">
       {bestsellerStore.list.map(b => (<div key={b.id}><h1>{b.name}</h1> <b>{b.typeName}</b></div>))} 
       </div>
       <div id="delivery">
        
       </div>

       <div id="about_us">
          
       </div>
    </>
  )
}
