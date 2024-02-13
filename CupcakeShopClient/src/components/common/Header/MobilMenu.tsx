import React from 'react';
import Popup from 'reactjs-popup';
import { useNavigate } from "react-router-dom";
import { ReactComponent as CloseImg } from "../../../assets/images/close.svg";
import styled from 'styled-components';
import Cupcake from '../../../assets/images/cupcake.png';
import { HashLink } from 'react-router-hash-link';


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


const ImgContainer = styled.div`
    display: flex;
    justify-content: center;
    margin-top: 5rem;

`;


const HeaderMobilLink = styled(HashLink)`
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

            <HeaderMobilLink onClick={() => { onClose(); }} to={'/#bestsellers'} >bestsellers</HeaderMobilLink>
            <HeaderMobilLink onClick={() => { onClose(); }} to={'/catalog'} >catalog</HeaderMobilLink>
            <HeaderMobilLink onClick={() => { onClose(); }} to={'/#delivery'} >delivery</HeaderMobilLink>
            <HeaderMobilLink onClick={() => { onClose(); }} to={'/#about_us'} >about us</HeaderMobilLink>
            <ImgContainer>
                <img src={Cupcake} />
            </ImgContainer>
        </Popup>
    );
};

export default MobilMenu;