import styled, { keyframes } from "styled-components";
import ArrowImg from "../../../assets/images/ArrowForAccardion.png";
import React, { useEffect, useRef, useState } from "react";





type QuestionInfo = {
    id: number,
    question: string,
    answer: string,
}


const questionList: QuestionInfo[] =
    [
        { id: 1, question: "Question 1.", answer: "Answer 1. Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit atque officia sapiente. Vero, hic architecto." },
        { id: 2, question: "Question 2", answer: "Answer 2. Lorem ipsum dolor sit amet consectetur, adipisicing elit. Commodi, consequuntur eveniet odio voluptatibus quaerat quisquam laboriosam fugit iste, nesciunt nisi quas consectetur officia a aliquid tempore praesentium quam ea! Error!" },
        { id: 3, question: "Question 3", answer: "Answer 3. Lorem ipsum dolor sit amet consectetur adipisicing elit." },
        { id: 4, question: "Question 4", answer: "Answer 4. Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusamus consequatur ratione a sapiente accusantium voluptas ipsa dolorum vitae placeat laudantium" },
    ]

const Container = styled.div`
    margin: 5rem auto 7rem auto;
    width: 40%;
`;


const showAnswerAnimation = keyframes`
    from{ margin-top: -100%; margin-bottom:100%; }
    to { margin-top: 0%; margin-bottom:0%; }
`;
const hideAnswerAnimation = keyframes`
    from{ margin-top: 0%; margin-bottom:0%; }
    to { margin-top: -100%; margin-bottom:100%; }
`;

const AnswerWrapper = styled.div`
     overflow: hidden;
    .selected{
        animation: ${showAnswerAnimation} 0.1s ;
       height: 100%;
    }
    .unSelected{
        animation: ${hideAnswerAnimation} 0.1s ;
        /*fix it*/
    }
`;
const AccordionItemContainer = styled.div``;
const QuestionContainer = styled.div`
    display: flex;
    border-bottom: 2px solid var(--color-dark);
    padding-bottom: 1rem;
    cursor: pointer;
    .selected{
        transform: rotate(180deg);
    }
`;
const Question = styled.div`
    font-size: var(--text-size-large);
    text-transform: uppercase;
`;
const Answer = styled.div`
    font-size: var(--text-size-medium);
    margin: 2rem 0 2rem 0;
    overflow: hidden;
    height: 0;/*fix it*/
`;
const StyledImg = styled.img`
    margin-left: auto;
    width: 24px;
    height: 14px;
`;

type AccItemProps = {
    questionInfo: QuestionInfo,
    idOfSelectedQuestion: number,
    handleToggle: (id: number, isSelected: boolean) => void,
}



const AccordionItem: React.FC<AccItemProps> = ({ questionInfo, idOfSelectedQuestion, handleToggle }) => {
    const { id, question, answer } = questionInfo;
    const [isSelected, setIsSelected] = useState(false);

    useEffect(() => {
        setIsSelected(id === idOfSelectedQuestion);

    }, [idOfSelectedQuestion]);

    const height = useRef<HTMLDivElement>(null);
    console.log(height.current?.clientHeight);

    return (
        <AccordionItemContainer>
            <QuestionContainer onClick={() => handleToggle(id, !isSelected)}>
                <Question>{question}</Question>
                <StyledImg
                    className={isSelected ? "selected" : ""}
                    src={ArrowImg}
                    alt="Arrow" />
            </QuestionContainer>
            <AnswerWrapper>
                <Answer className={isSelected ? "selected" : "unSelected"}><div ref={height}>{answer}</div></Answer>
            </AnswerWrapper>
        </AccordionItemContainer>
    )
}



export const Questions = () => {
    const [idOfSelectedQuestion, setIdOfSelectedQuestion,] = useState(-1);



    const handleToggle = (id: number, isSelected: boolean) => {
        setIdOfSelectedQuestion(
            isSelected ? id : -1
        );

    }

    return (
        <Container>
            {questionList.map(q => (
                <AccordionItem key={q.id}
                    handleToggle={handleToggle}
                    idOfSelectedQuestion={idOfSelectedQuestion}
                    questionInfo={q}
                />))}
        </Container>
    )
}
