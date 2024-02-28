import styled from 'styled-components'
import { ProductTypesEnum } from '../../../store/enums/productTypesEnum';
import { useEffect, useState } from 'react';

const Container = styled.div`
    display:flex;
    gap: 1.5rem;
    padding: 0 5% 1rem 2%;
    
    scroll-snap-type: x mandatory;	
	-webkit-overflow-scrolling: touch;
	overflow-x: scroll; 
     
    &::-webkit-scrollbar {           
         width: 0 !important;
    }

    .selected{
        background-color: var(--color-dark);
        color: var(--color-light);
    }
    
    @media (min-width: 958px) {
        padding: 0 5% 1rem 8%;
    }
`;
const FilterItem = styled.div`
    padding: 0 1rem ;
    display: flex;
    background-color: var(--color-light);
    font-size: var(--text-size-medium);
    font-family: var(--font-family-light);
    color: var(--color-dark);
    height: 42px;
    cursor: pointer;
    border: 2px solid var(--color-dark);
    border-radius: 100px;
    justify-content: center;
    align-items: center;
    text-transform: capitalize;

    scroll-snap-align: end;
	position: relative;
    
`;


export const Filter: React.FC<{ filterOnChange: (ProductType?: ProductTypesEnum) => void, defaultProductType?: ProductTypesEnum }> = ({ filterOnChange, defaultProductType }) => {

    const [selectedType, setSelectedType] = useState<ProductTypesEnum | undefined>(undefined);

    const filterClickHandler = (productType: ProductTypesEnum) => {
        const selectedProductType = (selectedType === productType) ? undefined : productType;
        setSelectedType(selectedProductType)
        filterOnChange(selectedProductType);
    }



    const categories = [
        { id: 1, value: ProductTypesEnum.cake },
        { id: 2, value: ProductTypesEnum.cookie },
        { id: 3, value: ProductTypesEnum.choux },
        { id: 4, value: ProductTypesEnum.pizza }
    ]

    useEffect(() => {
        if (defaultProductType) {
            filterClickHandler(defaultProductType);
        }


    }, [])

    return (
        <Container>
            {categories.map((productType) =>
            (<FilterItem
                key={productType.id}
                className={selectedType === (productType.value) ? "selected" : ""}
                onClick={() => filterClickHandler(productType.value)}>{ProductTypesEnum[productType.id]}</FilterItem>))}


        </Container>
    )
}
