import axios from "axios";
import { AdditionalParamsEndpoint, BestsellerEndpoint, CatalogEndpoint, OrderEndpoint, ProductDetailsInfoEndpoint, RecommendedProductsEndpoint } from "../configs";
import { Product } from "../store/types/product"
import mockApi from "./MockEndpoints";
import { ProductTypesEnum } from "../store/enums/productTypesEnum";
import { AdditionalProdParams, CatalogApiResult, DetailProductInfo, Order } from "../store/types";


const apiUrl = (!process.env.NODE_ENV || process.env.NODE_ENV === 'development') ? "https://localhost:7172/" : "cupcakeshop-cupcake_shop_api-1";

const baseApi = axios.create({
    baseURL: apiUrl,
    timeout: 10000,
    headers: {
        "Content-Type": "application/json",
    },
});

if (!process.env.NODE_ENV || process.env.NODE_ENV === 'development') {
    //mockApi(baseApi);
}

const Api = {
    getBestsellersAsync: async () => {
        return await baseApi<Product[]>(BestsellerEndpoint);
    },

    getCatalogAsync: async (page: number = 1, typeid?: ProductTypesEnum, groupBy: number = 15) => {
        let url = (typeid)
            ? `${CatalogEndpoint}?pageNumber=${page}&groupBy=${groupBy}&typeid=${typeid}`
            : `${CatalogEndpoint}?pageNumber=${page}&groupBy=${groupBy}`;
        return await baseApi<CatalogApiResult>(url);
    },

    getProductDetailInfoAsync: async (id: string) => {
        let url = `${ProductDetailsInfoEndpoint}?id=${id}`
        return await baseApi<DetailProductInfo>(url);
    },

    getRecommendedProductsAsync: async (id: string, count: number) => {
        //let url = `${RecommendedProductsEndpoint}?id=${id}&count=${count}`
        //return await baseApi<Product[]>(url);
        return await baseApi<Product[]>(BestsellerEndpoint);
    },

    getAdditionalParamsAsync: async (id: string) => {
        let url = `${AdditionalParamsEndpoint}?id=${id}`
        return await baseApi<AdditionalProdParams>(url);
    },

    postOrderAsync: async (order: Order) => {
        let url = `${OrderEndpoint}`
        return await baseApi.post(url, order);
    }
}

export default Api;
