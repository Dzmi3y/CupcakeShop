import { useEffect, useState } from "react";
import { useAppDispatch, useAppSelector } from "../hooks"
import { Bestseller } from "../store/types";
import { getBestsellers } from "../store/reducers/bestsellerReducer";


export const HomePage = () => {

  const bestsellerStore = useAppSelector(state => state.bestsellerStore);
 
  const dispatch = useAppDispatch();






  useEffect(() => {
    dispatch(getBestsellers())
  },
    [dispatch]);

  return (
    <>
      <div>HomePage</div>
       {bestsellerStore.list.map(b => (<div key={b.id}><h1>{b.name}</h1> <b>{b.typeName}</b></div>))} 
    </>
  )
}
