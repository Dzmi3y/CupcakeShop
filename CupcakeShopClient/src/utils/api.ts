import axios  from "axios";
import { BestsellerEndpoint, CatalogEndpoint } from "../configs";
import { Product } from "../store/types/product"
import mockApi from "./MockEndpoints";
import { ProductTypesEnum } from "../store/enums/productTypesEnum";
import { CatalogApiResult } from "../store/types";


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
      ? `${CatalogEndpoint}?page=${page}&groupBy=${groupBy}&groupBy=${typeid}`
      : `${CatalogEndpoint}?page=${page}&groupBy=${groupBy}`;
    return await baseApi<CatalogApiResult>(url);
  }
}

export default Api;
