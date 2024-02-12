import axios from "axios";
import { BestsellerApi } from "../configs";
import MockAdapter from "axios-mock-adapter";


const api = axios.create({
  baseURL: "https://example.com/api", 
  timeout: 10000, 
  headers: {
    "Content-Type": "application/json", 
  },
});

const mock = new MockAdapter(api);
mock.onGet(BestsellerApi).reply(200,  [
        {
            id: 1,
            name: "Cupcake1",
            typeId: 1,
            typeName: "Type1",
            weight: 100,
            price: 10,
            imgUrl: "img1",
        },
        {
            id: 2,
            name: "Cupcake2",
            typeId: 2,
            typeName: "Type2",
            weight: 200,
            price: 20,
            imgUrl: "img2",
        }
    ]
);


export default api;



