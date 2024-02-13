import { Route, Routes } from "react-router-dom";
import { NotFoundPage } from "./components/pages/NotFoundPage";
import { HomePage } from "./components/pages/HomePage/HomePage";
import { CatalogPage } from "./components/pages/CatalogPage";
import { OrderPage } from "./components/pages/OrderPage";
import { ProductPage } from "./components/pages/ProductPage";
import { Header } from "./components/common/Header/Header";
import { Footer } from "./components/common/Footer";
import styled from "styled-components";


const Container = styled.div`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
`;

const FooterWrapper = styled.div`
   margin-top: auto;
`;

function App() {
  return (
    <Container>
      <Header />
      <Routes>
        <Route path="/" Component={HomePage} />
        <Route path="/catalog" Component={CatalogPage} />
        <Route path="/order" Component={OrderPage} />
        <Route path="/product" Component={ProductPage} />
        <Route Component={NotFoundPage} />
      </Routes>
      <FooterWrapper>
        <Footer />
      </FooterWrapper>
    </Container>
  );
}

export default App;
