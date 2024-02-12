import React from 'react';
import Popup from 'reactjs-popup';
import { useNavigate } from "react-router-dom";
import { ReactComponent as CloseImg } from "../../assets/images/close.svg";
import styled from 'styled-components';


interface MyModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const popupStyle: React.CSSProperties = {
    width: "100%",
    height: "100%",
    backgroundColor: "var(--color-dark)",
    display: "block",
    padding: "3rem",
    
}

const Close = styled(CloseImg)`
    cursor: pointer;
    float: right;
    @media (min-width: 590px) {
        margin: 1rem;
        transform: scale(1.5);
    }
`;


const HeaderMobilItems = styled.span`
        display: block;
        font-family: var(--font-family-light);
        color: var(--color-light);
        font-size: var(--text-size-medium);
        text-decoration: none; 
        text-transform: uppercase; 
        margin-top: 2rem;
        cursor: pointer;
        @media (min-width: 590px) {
            font-size: var(--text-size-large);
            margin: 3rem;
        }
`;

const MobilMenu: React.FC<MyModalProps> = ({ isOpen, onClose }) => {
    const navigate = useNavigate();

    return (
        <Popup contentStyle={popupStyle} open={isOpen} onClose={onClose} >

            <Close onClick={onClose} />

            <HeaderMobilItems onClick={() => { onClose(); navigate('/#bestsellers'); }} >bestsellers</HeaderMobilItems>
            <HeaderMobilItems onClick={() => { onClose(); navigate('/catalog'); }} >catalog</HeaderMobilItems>
            <HeaderMobilItems onClick={() => { onClose(); navigate('/#delivery'); }} >delivery</HeaderMobilItems>
            <HeaderMobilItems onClick={() => { onClose(); navigate('/#about_us'); }} >about us</HeaderMobilItems>


        </Popup>
    );
};

export default MobilMenu;