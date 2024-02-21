import React, { useEffect, useRef, useState } from 'react'
import styled from 'styled-components'
import ArrowImg from '../../assets/images/DropDownArrow.png'


export type DropdownItem = {
    id: number,
    text: string
}

const Container = styled.div`
    position: relative;
    cursor: pointer;
    .visible{
       display :flex;
       
    }
`;

const MainField = styled.div`
    height: 60px;
    color: var(--color-dark);
    font-size: var(--text-size-medium);
    background-color: var(--color-pale-yellow);
    border-radius: 10px;
    display: flex; 
    align-items: center;
    .opened{
        transform: rotate(180deg);
    }
`;

const Title = styled.span`
    margin-left: 20px;
`;

const Item = styled.div`
    word-wrap: break-word;
    padding: 5px 20px;
    &:hover{
        color: var(--color-black);
    }
`;

const ValuesBox = styled.div`
    margin-top: -15px;
    padding: 1rem 0;
    color: var(--color-dark);
    font-size: var(--text-size-medium);
    background-color: var(--color-pale-yellow);
    border-radius: 10px;
    display: none; 
    flex-direction: column;
    position: absolute;
    left: 0;
    right: 0;
`;

const StyledImg = styled.img`
    width: 19px;
    height: 9px;
    margin-left: auto;
    margin-right: 20px;
`;


export const Dropdown: React.FC<{ list: DropdownItem[], onSelected: (id: number) => void }> = ({ list, onSelected }) => {
    const [listIsVisible, setListIsVisible] = useState<boolean>(false);
    const [selectedItem, setSelectedItem] = useState<DropdownItem>();
    const containerElementRef = useRef<HTMLDivElement>(null);

    const resultList = list.filter((item)=>item.id!==selectedItem?.id);

    const toggleListVisibility = () => {
        setListIsVisible(!listIsVisible);
    }


    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (containerElementRef.current && !containerElementRef.current.contains(event.target as Node)) {
                setListIsVisible(false);
            }
        };

        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    const selected = (item: DropdownItem) => {
        setSelectedItem(item)
        onSelected(item.id)
        setListIsVisible(false);
    }

    useEffect(() => {
        selected(list[0]);
    }, []);


    return (
        <Container className='dropdown' ref={containerElementRef}>
            <MainField onClick={toggleListVisibility}>
                <Title>{selectedItem?.text}</Title>
                <StyledImg className={listIsVisible ? 'opened' : ''} src={ArrowImg} alt='arrow' />
            </MainField>
            <ValuesBox className={listIsVisible ? 'visible' : ''}>
                {resultList.map((item) => (
                    <Item key={item.id}
                        onClick={()=>selected(item)}>
                        {item.text}
                    </Item>))}
            </ValuesBox>
        </Container>
    )
}
