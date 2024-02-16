import axios from "axios";
import { BestsellerEndpoint, CatalogEndpoint } from "../configs";
import MockAdapter from "axios-mock-adapter";
import productsList from "../configs/data.json"
import { Product } from "../store/types/product"


export enum ProductTypesEnum {
  cake = 1,
  cookie,
  choux,
  pizza
}


const randomize = (array: Product[]) => {
  let currentIndex = array.length;
  let randomIndex;

  while (currentIndex > 0) {
    randomIndex = Math.floor(Math.random() * currentIndex);
    currentIndex--;

    [array[currentIndex], array[randomIndex]] = [array[randomIndex], array[currentIndex]];
  }
}

const baseApi = axios.create({
  baseURL: "https://example.com/api",
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});


let bestsellersList: Product[] = [];


(productsList as Product[]).map(p => {
  let typeId = Math.floor(bestsellersList.length / 4) + 1;
  if (p.typeId === typeId)
    bestsellersList.push(p);
}
);

randomize(bestsellersList);


const getFilteredData = (pageN?: number, typeId?: number) => {
  pageN ??= 1;
  let groupBy = 15;
  let end = groupBy * pageN
  let start = end - groupBy;

  return productsList
    .filter((p) => (!typeId) || (p.typeId == typeId))
    .slice(start, end);
}

const mock = new MockAdapter(baseApi);
mock.onGet(BestsellerEndpoint).reply(200, bestsellersList);


function parseQueryString(url: string) {
  const queryString = url.replace(/.*\?/, "");

  if (queryString === url || !queryString) {
    return null;
  }

  const urlParams = new URLSearchParams(queryString);
  const result: any = {};

  urlParams.forEach((val, key) => {
    if (result.hasOwnProperty(key)) {
      result[key] = [result[key], val];
    } else {
      result[key] = val;
    }
  });

  return result;
}

mock.onGet(/\/catalog\/?(.*)/).reply((config) => {
  let params = parseQueryString(config.url as string)

  let page: number | undefined = params.page as number;
  let filter: number | undefined = params.filter as number;

  return [200, getFilteredData(page, filter)];
});


const Api = {
  getBestsellersAsync: async () => {
    return await baseApi<Product[]>(BestsellerEndpoint);
  },

  getCatalogAsync: async (page?: number, productType?: ProductTypesEnum) => {
    let _page = page || 1;
    let url = (productType)
      ? `${CatalogEndpoint}?page=${_page}&filter=${productType}`
      : `${CatalogEndpoint}?page=${_page}`;
    return await baseApi<Product[]>(url);
  }
}


export default Api;

