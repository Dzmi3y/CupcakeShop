import axios from "axios";
import { AdditionalParamsEndpoint, BestsellerEndpoint, CatalogEndpoint, OrderEndpoint, ProductDetailsInfoEndpoint, RecommendedProductsEndpoint } from "../configs";
import { Product } from "../store/types/product"
import mockApi from "./MockEndpoints";
import { ProductTypesEnum } from "../store/enums/productTypesEnum";
import { AdditionalProdParams, CatalogApiResult, DetailProductInfo, Order } from "../store/types";


const baseApi = axios.create({
  baseURL: "https://example.com/api",
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});


mockApi(baseApi);


const Api = {
  getBestsellersAsync: async () => {
    return await baseApi<Product[]>(BestsellerEndpoint);
  },

  getCatalogAsync: async (page: number = 1, typeid?: ProductTypesEnum, groupBy: number = 15) => {
    let url = (typeid)
      ? `${CatalogEndpoint}?page=${page}&groupBy=${groupBy}&typeid=${typeid}`
      : `${CatalogEndpoint}?page=${page}&groupBy=${groupBy}`;
    return await baseApi<CatalogApiResult>(url);
  },

  getProductDetailInfoAsync: async (id: number) => {
    let url = `${ProductDetailsInfoEndpoint}?id=${id}`
    return await baseApi<DetailProductInfo>(url);
  },

  getRecommendedProductsAsync: async (id: number, count: number) => {
    let url = `${RecommendedProductsEndpoint}?id=${id}&count=${count}`
    return await baseApi<Product[]>(url);
  },

  getAdditionalParamsAsync: async (id: number) => {
    let url = `${AdditionalParamsEndpoint}?id=${id}`
    return await baseApi<AdditionalProdParams>(url);
  },

  postOrderAsync: async (order: Order) => {
    let url = `${OrderEndpoint}`
    return await baseApi.post(url, order);
  }
}

export default Api;
