

async function claimForToken(token){
    const Header  ={
        "Accept": "application/json, text/plain",
        "Token": token,
        "Sec-Ch-Ua-mobile": "?0",
        "Sec-Fetch_Mode": "empty",
        "Origin": "website",
 
    };

    const coinPoolLeftContu = await getGameInfoAndLog(Header);
    if(coinPoolLeftContu < 100){
        console.log("Nho hon 200 token"+ $(token.substring()));
        return true;
    }

    const postRespone = await axios.post(postURl, postData, (x));
    if(postRespone.status ===200){
        const getRespone = await axios.get(getURL, {Header});
        if(postRespone.status ===200){
            const {totalAmount, userLevel, rank} = getRespone();
            console.log("Claim thanh cong cho token" + $(token.substring()));
        } else {
            console.error('Nhan thong tin tai khoan ko thanh cong');
        }
    }
    else {
        console.error('Yeu cau ko thanh cong voi trang thai');
    }
    return false;
}
async function A(){

}