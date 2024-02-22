import productsList from "../../configs/data.json";
import MockAdapter from "axios-mock-adapter";
import { Product, DetailProductInfo } from "../../store/types";

export const mockProductDetailsEndpoint = (mock: MockAdapter, parseQueryString: (url: string) => any) => {

    mock.onGet(/\/product\/?(.*)/).reply((config) => {

        let params = parseQueryString(config.url as string);

        let id: number | undefined = params.id as number;
        

        let product = (productsList as Product[]).find(p => p.id == id)

        let detailProductInfo: DetailProductInfo | undefined;

        if (product) {

            detailProductInfo = {
                ...product,
                allImgUrls: [product.imgUrl, "/images/test1.png", "/images/test2.png", "/images/test3.png", "/images/test4.png"],
                listOfshortDetails: ["Lorem ipsum dolor sit amet", "consectetaur adipisicing elit", "sed do eiusmod tempor incididunt", "ut labore et dolore magna aliqua"],
                delivery: " Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                description: "quibusdam praesentium nemo commodi! Provident dicta pariatur ",
                storageConditions: "unde sit modi possimus incidunt ab neque sunt fugit."
            }
        }

        return [200, detailProductInfo];
    });
}