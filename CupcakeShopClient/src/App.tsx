import { Route, Routes } from "react-router-dom";
import { NotFoundPage } from "./pages/NotFoundPage";
import { HomePage } from "./pages/HomePage";
import { CatalogPage } from "./pages/CatalogPage";
import { OrderPage } from "./pages/OrderPage";
import { ProductPage } from "./pages/ProductPage";
import { Header } from "./components/Header/Header";
import { Footer } from "./components/Footer";
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
