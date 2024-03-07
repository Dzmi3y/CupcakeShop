import additionWeightData from "../../configs/additionWeightData.json";
import subspeciesData from "../../configs/subspeciesData.json";
import decorData from "../../configs/decorData.json";


import MockAdapter from "axios-mock-adapter";
import { AdditionalProdParams } from "../../store/types";

export const mockAdditionalProductParameterEndpoint = (mock: MockAdapter) => {

    mock.onGet(/\/Product\/GetAdditionalParams\/?(.*)/).reply((config) => {

      const additionalProdParamApiResult: AdditionalProdParams={
        decorations:decorData,
        subspecies:subspeciesData,
        weights:additionWeightData
      }

        return [200, additionalProdParamApiResult];
    });
}