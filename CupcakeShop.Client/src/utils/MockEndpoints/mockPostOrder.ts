import MockAdapter from "axios-mock-adapter";
import { Order } from "../../store/types";

export const mockPostEndpoint = (mock: MockAdapter) => {

    mock
        .onPost("/Order/SaveOrder", {
            asymmetricMatch: (actual: Order) => {
                return "The order was placed successfully";
            },
        })
        .reply(200, "The order was placed successfully");
}