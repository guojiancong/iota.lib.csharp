﻿using System;
using Iota.Api.Model;
using Iota.Api.Pow;
using Iota.Api.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iota.Api.Tests.Utils
{
    [TestClass]
    public class SigningTest
    {
        private static readonly string TEST_SEED =
            "IHDEENZYITYVYSPKAURUZAQKGVJEREFDJMYTANNXXGPZ9GJWTEOJJ9IPMXOGZNQLSNMFDSQOTZAEETUEA";

        private static readonly string FIRST_ADDR =
            "LXQHWNY9CQOHPNMKFJFIJHGEPAENAOVFRDIBF99PPHDTWJDCGHLYETXT9NPUVSNKT9XDTDYNJKJCPQMZCCOZVXMTXC";

        private static readonly string SIXTH_ADDR =
            "HLHRSJNPUUGRYOVYPSTEQJKETXNXDIWQURLTYDBJADGIYZCFXZTTFSOCECPPPPY9BYWPODZOCWJKXEWXDPUYEOTFQA";

        private static readonly string SIGNATURE1 =
            "PYWFM9MYTPNZ9HTLZBBB9CGQWKPALDUNAQYCAA9VMQ9UMBLLAXSPPHQSNAAKJA9MZBXBHBQBFFKMBSDHDTCVCDWLUYCEQ9YZJAJAXXXZHDWTSLWGIWRE9LJFVWAFUMOAGHDBHJQ9APNBLSX9GPTJNTO9SBJT9UKYCZXYAWVGXEBJANNWEWZSPRYHASHGIFUWOEHUFMP9MWQBYZOZESCPLVJUCWGLEJIDPMEVNPBITBNFSQ9GBWCDTQZOPLPXOWWNQAEIXQRWMHAQDH9C9KKHGNKAX9INMUVVGIK9TPGRHOMDFAB9VICYDMSHHDDBRSTEFSZXMXFJUQRRAFBSCNHSMKRNNTTCMBURKBGC9EDWKLPBSQAKYCUKKSZWRVURZGUA9QVSXXPICIYFHLPJSWEFBZPUTWWNIKSAJM9OMRFFQVFJZZHLQBSEYXM9CN9HCGHSJBTYDGWOQPXOPZZE9EPQAQFT9GDWZCSOPMZHYYZXDDZ9DJDLOOOTIFQANFANNAYVIRUNDXSB9XRNXJYRDBLTEDWSUOVISMCHGKD9KDRSFDWRSVZQQKGAMDXFAWBSLMTTUMH9RAUIVI9HJMTODACSOP9MLHOJMSIWQ9TTNGPXRNWRHLMEMAH9GZHJRNJHQNBBLWKFXIZBMGMATZIZBFDPAFDCLDIFFAIK9JUSFYYC9ANDGXCZFLZYGURTUI9SWYYRGDJAHXDDNHSJZBCENZUSQXSFZMTXSFLRK9RIYAUMHPBOBNOXCHDIMBGIBVOOHIDQ9ORHHDECDTREIEILWDUFMUWYMGIXBIKRZMKGXTYZTX9GKFP9AUXMTUUQXRHHKPYULGJFJLEEYCNKLOWULRIAFM9OYKEDFRXFVTSJMSEMOURCLNOIETIHEUCMPLWKDXDO9TAHVH99MKTBAAKCMYKLJUQIVLLSVTFUM9KDSIHYXYHPRLDADSLSSOIGLLXMPKTHS9YXUNMUTBTBPDWXA9GVTBGLTCLEZEUNNIRBBURDWOFFYXELPFSZRQARVRPHGETKJTRUZIFDDWBOHHGUZTODZFMOVMAGCYCTGBWSGAVZADIPIASCKTRKIUUMHNGUYZKDVOPKKHXD9EXVUVJ9YFNYMLIJLEEGPIZLFS9FIEMG9MIEO9FPW9JZEVDQOECMTESICSMVWXZNXXJILJLVQHEBHQWPOBHKEGRLFCPLB9ZECJOZDAB9DMU9UALBIQDABVDYRRTPMZOCQX9WNGXVNKQZWPA9ACVONQMRHQDPPIQTP9VKP9PAORNOFTZZWGC9RYBWSNLULZGYLMYIWWPDMOHPZTQWRPRCN9RAUOKDSCWBRI9NPUPLBILOZDOOPHSWQGJEGUYWAWJDEBLEOBSYYU9XSRPBHRUQXIDOWJZQQVJTMP9VLWLOGBK9FZFHYLJCNENDATNPSF99DFPVPTNNKIUMHRGEBJXNUVENAHYLFPPHYFTIKCB9DBVCCSJTDMOMISBAAEJVBVLHOADKNFG9NQGIGRDICQCWZVHGGXLTUNQKBUTLDWXIM9REWBLIXFBPTOXBLWBQQUSRLRDHTXQWARPMBQILAJSYLLTDAGTFPCXBCDITDOIZNGKPZQWWHJDZIPYCPFEYFD9CVXYOJHJNUNMCMSIAUVSKCACNNPGDYJJVTZOREJOPIBYCMBULMTSDTJPZNVNYQBQPPABOSSNZJKQQZ9LULSHJUBLHIFMYWSNPGUERCLVFV9LOEBJEERYHI9OMSMSCDFDLNHEMLQXNRJDYSNKTOYCPTAUWAWIGCPJKMAMGLXNBJMO9BZGFIHWDVJWYCNZZV9KBWIFQSMAXBPGVXDW9SLTHOLMJORRXZJSTNOQDRGNBLGTFCCNBJECYZGWTDRJKJRBAJRCULMOUBQJFWCLWMEWGAAVNZWMDWBYDKZMUCZAKXQLRQPIQJPMORKJXKSDTGXWDHAKUOSMXCFXWSZYWXODWFACBMFSWQFVMBELPZMISVWRQQQPNHOTWOEQQAQJDLXFEEBXLJQEECWG9ARRRDLTVBHTPARJMLOZHYWDCSXPTZCNZWTCRUJNZWKFZXAARPHFCBTLWSLERGJJMKIG9NEBADRMZWYNWIRGTMOBRKURUE9GDLRIEODY9BXJOZUVNCXKXFPFDXKUTMXZRJDOQ9YTV9BJDKGZBYTWGVPQQMNVCNARLPSRQWN9TRMHWLNEJZFTCSRD";

        private static readonly string SIGNATURE2 =
            "URKFKLNXFEKDOGSQVMAOPEDIWSMTCKJZ9KEVWYALY9JAO9KHUGNDTMGQLKQJUIPWDIVMPEDSVPLFMDCIXDDT9WBBRTFQENL9AXLSBYHINXCDYBFGRNKJDYHAQVJKWCVOYXHTNBEZUNLVMJLUMZYJFAOW9PVVMJZNZZFJQEQFELVFZVFVWPJ9WQZJLPSGBYECHXSFVFQJGUCPFXC9GATTILVCAANNHOYMLOYX9QSUPCERYCOXPACZEEGLREBRZWXGUTTVTHB9GBRCIFEOBPIRXXPQKRSODEHDSZXLGIKXUQWNTQKIOPVDVSIK9WJUAEFOJBU9MBPBSVYSCLBMINTT9ZCTREZSMSVOPXSZOMCGFEZKMOCNLJ9QUTAPKBHRIAIYLCHUQHOINKSCMXWZVDGDXHNJQXJHPCCGBEWROVKEPAPBFFRCAVXZWIRKCRAWYHIHMDXFAGDJQNJJPYSQUHKFOOCEVQOGRQEIOQFKZWUQ9XVRNXKGMJOQEZHQZXQABWUQRBKXWHYUXEAEMDGXVY9WS9VJOCMGBQASSRNKAYJPTSPQEMYSJMTCLMDQJKDPBGQZZSFBDOKHBYY9UDRXNKTPWBCQTVKUGMEDUXL9TTKPATNIKVAGHACHPFSCRYNIRJBQC9OADPGWBFYYARSVNQCGMYQGCYLZH9KLMUIJPCLPQVS9BORXCJBXPDECJGKDNOUYWTKKFLXZARWKGUSMVMXKJTMRYZRERFCFGTZFZFCAOQSZGPQJUEZUJLJPU9QPMJUTZNLMSMPRGIFHUUZHMPMRBEBATEIIWPCOIMWOYOG9NYFBYOWFDKRXOTREBU99GNCPXKOWGI99LNVPRFFF9FCLFXI9HMUFU9NRLNJVTFNUSUJTAVOG9GKUYYEXIM9HTPIDTWIGLKRAQPKMQVZAPYMPSQIOJ9JZBWDMQHDSSRSHNCWSAJCSRORSEXLLQNZUKPXPGRLYMXOXWCCWWSBALFLXPHSGFLTOAFWPETBKJUMBLHMSKYLPJT9EJAZCPPNZWKPVCGKDJCRCLBBIAKVDSNWGONPLKFAYXZDI9FKPHDPKCB9UUPXLJVQTXOAZOQDRNSONXDVSLQGZYRIPGREYHRAUOSBFZDZPZHFNMWCZQGPXCZVLNCSASB9RQDFHOYMUVYLFKOEEWNREYCDMCTZIAFBFKLKRQWZCJHQZCZGWXIFTKRVMPHMVHAABHBDEV9WDEZBR9FLXLNBVNYKUOUFJQKNZVZVGZDDTFYNYFUVRLZKOLXXQYNV9MDVBLZSERXPGYKRIEZQZD9IBKFDT9AIYGWJJCXFWDUDURGJQLXVEJAVEOMZUVVTNCVBXEVQRDQIEHDUCSLCIJUTSCLFXEGMFYP9YLXELCZPMTBZWBIODZCFNJLVWTPQGLMQIHIABAYGJFFMOEDTCXGEDTNXMVXZYFGXRKVVRTIZ9ISXTDHAFPEKQZSM9XXQLOYBLTMD9MBERBIBEJDEXGMOLDZPZVVEPIRKJBDPAKFAWJPTCJSHZPDUKZEEHRFLMZCUGCOWFJBSTDGPHUIXSPPPHRQARMCFMTWKYPJNJQV9VSFZ9EWB9GVEAFUXHWRNUXQLCSBWROOITBATWUXUYGSMGAXKGEBP9ZJWXQWHBVPOSLDHTWXUOFQNO9EXSYPQF9LQLQAFNRU9MTIIRQLBBBYKUPANWRQKGESFARQIRUTGFMZVUKHZJYKTYOARTDOBIYBFRHJWEFHCYVHRHTLTWBRMUDVIVQVNELQMQRXYDNGVSICZINWIZCIWVFXLYOLYKWDNWCWFZUXHUWOPRDHMTSXOZX9CVHANU9ZXTJOGKEPYR9CHGOTIUQSWIALAOIKHQFXWY9ZWTSZADVXJNNZOLSCXVVFBRHLRBTGMSZOYNIXTAMABKGJTLGTZKRHOPPJMNYIQNVKRGXUQDWYEIEZYM9CSXO9YLSBJLDJUWOLUXDEKBGGEIDEXFLZMESDOITNYTNRLGOMHJH9HOLXJABUNLXCZYTXFPZMHRJPLXSVPDBJBBZX9TBIMZZFZOXUSFEJYHEXPFXGJCQTBBLPEEWAPHUETGXSXYYAF9PCCCOONRMQGAPJ9JO9BZQ9QSKTPFFYIFVHSLAZY9CWYSIMKDOSLRKWBHPGJGVEJEEMLCCWXKSOCMBMZZZJWYBBXE9FTAYJALGWITJRXAXWZEXMECTZEEIWZPHYX";

        private static readonly string ADDR_SEED =
            "LIESNFZLPFNWAPWXBLKEABZEEWUDCXKTRKZIRTPCKLKWOMJSEREWKMMMODUOFWM9ELEVXADTSQWMSNFVD";

        private static readonly string ADDR_I0_S1 =
            "HIPPOUPZFMHJUQBLBVWORCNJWAOSFLHDWF9IOFEYVHPTTAAF9NIBMRKBICAPHYCDKMEEOXOYHJBMONJ9D";

        private static readonly string ADDR_I0_S2 =
            "BPYZABTUMEIOARZTMCDNUDAPUOFCGKNGJWUGUXUKNNBVKQARCZIXFVBZAAMDAFRS9YOIXWOTEUNSXVOG9";

        private static readonly string ADDR_I0_S3 =
            "BYWHJJYSHSEGVZKKYTJTYILLEYBSIDLSPXDLDZSWQ9XTTRLOSCBCQ9TKXJYQAVASYCMUCWXZHJYRGDOBW";

        private static readonly string ADDR_LS_I0_S1 =
            "VKPCVHWKSCYQNHULMPYDZTNKOQHZNPEGJVPEHPTDIUYUBFKFICDRLLSIULHCVHOHZRHJOHNASOFRWFWZC";

        private static readonly string ADDR_LS_I0_S2 =
            "PTHVACKMXOKIERJOFSRPBWCNKVEXQ9CWUTIJGEUORSKWEDDJCBFQCCBQZLTYXQCXEDWLTMRQM9OQPUGNC";

        private static readonly string ADDR_LS_I0_S3 =
            "AGSAAETPMSBCDOSNXFXIOBAE9MVEJCSWVP9PAULQ9VABOTWLDMXID9MXCCWQIWRTJBASWPIJDFUC9ISWD";

        [TestMethod]
        public void TestAddressGeneration()
        {
            Assert.AreEqual(FIRST_ADDR, IotaApiUtils.NewAddress(TEST_SEED, 2, 0, true, null));
            Assert.AreEqual(SIXTH_ADDR, IotaApiUtils.NewAddress(TEST_SEED, 2, 5, true, null));

            Assert.AreEqual(ADDR_I0_S1, IotaApiUtils.NewAddress(ADDR_SEED, 1, 0, false, null));
            Assert.AreEqual(ADDR_I0_S2, IotaApiUtils.NewAddress(ADDR_SEED, 2, 0, false, null));
            Assert.AreEqual(ADDR_I0_S3, IotaApiUtils.NewAddress(ADDR_SEED, 3, 0, false, null));

            Assert.AreEqual(ADDR_LS_I0_S1, IotaApiUtils.NewAddress(ADDR_SEED + ADDR_SEED, 1, 0, false, null));
            Assert.AreEqual(ADDR_LS_I0_S2, IotaApiUtils.NewAddress(ADDR_SEED + ADDR_SEED, 2, 0, false, null));
            Assert.AreEqual(ADDR_LS_I0_S3, IotaApiUtils.NewAddress(ADDR_SEED + ADDR_SEED, 3, 0, false, null));
        }

        [TestMethod]
        public void TestLongSeedKeyGeneration()
        {
            ICurl curl = new Kerl();
            var signing = new Signing(curl);
            var seed = "EV9QRJFJZVFNLYUFXWKXMCRRPNAZYQVEYB9VEPUHQNXJCWKZFVUCTQJFCUAMXAHMMIUQUJDG9UGGQBPIY";

            for (var i = 1; i < 5; i++)
            {
                var key1 = signing.Key(Converter.ToTrits(seed), 0, i);
                Assert.AreEqual(Signing.KeyLength * i, key1.Length);
                var key2 = signing.Key(Converter.ToTrits(seed + seed), 0, i);
                Assert.AreEqual(Signing.KeyLength * i, key2.Length);
                var key3 = signing.Key(Converter.ToTrits(seed + seed + seed), 0, i);
                Assert.AreEqual(Signing.KeyLength * i, key3.Length);
            }
        }

        [TestMethod]
        public void TestSigning()
        {
            // we can sign any hash, so for convenience we will sign the first
            // address of our test seed
            // (but remove the checksum) with the key of our fifth address
            var hashToSign = FIRST_ADDR.RemoveChecksum();
            var signing = new Signing(null);
            var key = signing.Key(Converter.ToTrits(TEST_SEED), 5, 2);
            var normalizedHash = new Bundle().NormalizedBundle(hashToSign);

            var subKey = new int[6561];
            var subNormalizedHash = new int[27];

            Array.Copy(key, 0, subKey, 0, 6561);
            Array.Copy(normalizedHash, 0, subNormalizedHash, 0, 27);
            var signature = signing.SignatureFragment(
                subNormalizedHash,
                subKey);
            Assert.AreEqual(SIGNATURE1, Converter.ToTrytes(signature));

            Array.Copy(key, 6561, subKey, 0, 6561);
            Array.Copy(normalizedHash, 27, subNormalizedHash, 0, 27);
            var signature2 = signing.SignatureFragment(
                subNormalizedHash,
                subKey);
            Assert.AreEqual(SIGNATURE2, Converter.ToTrytes(signature2));
        }

        [TestMethod]
        public void TestKeyLength()
        {
            var signing = new Signing(null);
            var key = signing.Key(Converter.ToTrits(TEST_SEED), 5, 1);
            Assert.AreEqual(Signing.KeyLength, key.Length);
            key = signing.Key(Converter.ToTrits(TEST_SEED), 5, 2);
            Assert.AreEqual(2 * Signing.KeyLength, key.Length);
            key = signing.Key(Converter.ToTrits(TEST_SEED), 5, 3);
            Assert.AreEqual(3 * Signing.KeyLength, key.Length);
        }

        [TestMethod]
        public void TestVerifying()
        {
            var signing = new Signing(null);
            Assert.IsTrue(signing.ValidateSignatures(
                RemoveChecksum(SIXTH_ADDR),
                new[] {SIGNATURE1, SIGNATURE2},
                RemoveChecksum(FIRST_ADDR)));
        }

        private string RemoveChecksum(string address)
        {
            Assert.IsTrue(address.IsValidChecksum());
            return address.Substring(0, 81);
        }
    }
}