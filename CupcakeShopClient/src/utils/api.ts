import axios from "axios";
import { BestsellerApi } from "../configs";
import MockAdapter from "axios-mock-adapter";
import productsList from "../configs/data.json"
import { Product } from "../store/types/product"


const randomize = (array: Product[]) => {
  let currentIndex = array.length;
  let randomIndex;

  while (currentIndex > 0) {
    randomIndex = Math.floor(Math.random() * currentIndex);
    console.log(randomIndex);
    currentIndex--;

    [array[currentIndex], array[randomIndex]] = [array[randomIndex], array[currentIndex]];
  }
}

const api = axios.create({
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

console.log(bestsellersList);
console.log(bestsellersList.sort(() => Math.random() - 0.5))

const mock = new MockAdapter(api);
mock.onGet(BestsellerApi).reply(200, bestsellersList);


export default api;



