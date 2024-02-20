import { useNavigate, useSearchParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { getAdditionalParams, getDetailProductInfo, getRecommendedProducts } from "../../../store/reducers/detailProductReducer";
import { useEffect } from "react";


export const ProductPage = () => {
  const navigate = useNavigate();
  const [queryParameters] = useSearchParams();
  const id = queryParameters.get("id");
  const detailProductStore = useAppSelector(state => state.detailProductStore);
  const dispatch = useAppDispatch();

  useEffect(()=>{
    dispatch(getDetailProductInfo(Number(id)));
    dispatch(getAdditionalParams(Number(id)));
    dispatch(getRecommendedProducts({id:Number(id),count:4}));
  },[dispatch]);




  return (
    <div>ProductPage</div>
  )
}
