import React, { useState } from 'react'
import styled from 'styled-components'
import Arrow from '../../../assets/images/photosSliderArrow.png'

const Container = styled.div`
`;

const MainImg = styled.img`
  width: 100%;
`;

const SliderContainer = styled.div`
  margin: 1rem 0;
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
`;

const Slider = styled.div`
  display: flex;
  gap: 1rem;

  scroll-snap-type: x mandatory;	
	-webkit-overflow-scrolling: touch;
	overflow-x: scroll; 
  &::-webkit-scrollbar {           
       width: 0 !important;
  }
`;

const ItemImg = styled.img`
  cursor: pointer;
  width: 75px;
  height: 75px;
  scroll-snap-align: end;
`;

const LeftNavImg = styled.img`
  width: 35px;
  height: 35px;
  cursor: pointer;
`;

const RightNavImg = styled.img`
  width: 35px;
  height: 35px;
  transform: rotate(180deg);
  cursor: pointer;
`;

export const ProductImgSlider: React.FC<{ urls: string[] | undefined }> = ({ urls = [] }) => {
  const [selectedImageNumber, setSelectedImageNumber] = useState<number>(0);
  const changeImg = (imageNumber: number) => {
    if ((0 <= imageNumber) && (imageNumber < urls.length)) {
      setSelectedImageNumber(imageNumber);
    }
  }


  return (
    <Container>
      <MainImg src={urls[selectedImageNumber]} />
      <SliderContainer>
        <LeftNavImg src={Arrow} onClick={() => changeImg(selectedImageNumber - 1)} />
        <Slider>
          {urls.map((url, i) => (
            (selectedImageNumber !== i)) && <ItemImg key={i} src={url} onClick={() => changeImg(i)} />
          )}
        </Slider>
        <RightNavImg src={Arrow} onClick={() => changeImg(selectedImageNumber + 1)} />

      </SliderContainer>
    </Container>
  )
}
