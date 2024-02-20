import React from 'react'
import { Link } from 'react-router-dom';
import styled from 'styled-components';

export type BreadCrumbsItem = {
    title: string;
    link: string | null;
}

const Container = styled.nav`
    font-size: var(--text-size-small);
    font-family: var(--font-family-light);
    display: flex;
`;

const Item = styled(Link)`
    color: var(--color-black);
    text-decoration: none;
    text-transform: capitalize;
    margin-left: 4px;
`;

const CurrentPage = styled.span`
    color: var(--color-dark);
    text-transform: capitalize;
    margin-left: 4px;
`;

export const BreadCrumbs: React.FC<{ breadCrumbsList: BreadCrumbsItem[] }> = ({ breadCrumbsList }) => {
    return (
        <Container>
            {breadCrumbsList.map((b, i) =>
                (breadCrumbsList.length === i + 1)
                    ? (<CurrentPage key={i}>{b.title}</CurrentPage>)
                    : (<Item key={i} to={b.link as string}>{b.title + " /"}</Item>)
            )}
        </Container>
    )
}
