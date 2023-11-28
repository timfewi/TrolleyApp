using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trolley.DataSeeder.Data
{
    public static class GlobalIds
    {
        //Market ids
        public static readonly Guid MarketBillaId = Guid.Parse("00000000-0000-0000-1000-000000000001");
        public static readonly Guid MarketSparId = Guid.Parse("00000000-0000-0000-1000-000000000002");
        public static readonly Guid MarketHoferId = Guid.Parse("00000000-0000-0000-1000-000000000003");
        public static readonly Guid MarketLidlId = Guid.Parse("00000000-0000-0000-1000-000000000004");
        public static readonly Guid MarketPennyId = Guid.Parse("00000000-0000-0000-1000-000000000005");
        public static readonly Guid MarketInterSparId = Guid.Parse("00000000-0000-0000-1000-000000000006");
        public static readonly Guid MarketBillaPlusId = Guid.Parse("00000000-0000-0000-1000-000000000007");
        public static readonly Guid MarketEuroSparId = Guid.Parse("00000000-0000-0000-1000-000000000008");


        //Brand ids
        public static readonly Guid BrandJaNatuerlichId = Guid.Parse("00000000-0000-0000-2000-000000000001");
        public static readonly Guid BrandCleverId = Guid.Parse("00000000-0000-0000-2000-000000000002");
        public static readonly Guid BrandSbudgetId = Guid.Parse("00000000-0000-0000-2000-000000000003");


        //Category ids
        //Main categories
        public static readonly Guid MainCatObstId = Guid.Parse("00000000-0000-0000-0000-100000000001");
        public static readonly Guid MainCatGemueseId = Guid.Parse("00000000-0000-0000-0000-100000000002");
        public static readonly Guid MainCatFleischId = Guid.Parse("00000000-0000-0000-0000-100000000003");
        public static readonly Guid MainCatFischId = Guid.Parse("00000000-0000-0000-0000-100000000004");
        public static readonly Guid MainCatMilchProdukteId = Guid.Parse("00000000-0000-0000-0000-100000000005");
        public static readonly Guid MainCatBackwarenId = Guid.Parse("00000000-0000-0000-0000-100000000006");
        public static readonly Guid MainCatSuesswarenId = Guid.Parse("00000000-0000-0000-0000-100000000007");
        public static readonly Guid MainCatGetraenkeId = Guid.Parse("00000000-0000-0000-0000-100000000008");
        public static readonly Guid MainCatTiefkuehlId = Guid.Parse("00000000-0000-0000-0000-100000000009");
        public static readonly Guid MainCatSonstigesId = Guid.Parse("00000000-0000-0000-0000-100000000010");

        //Sub categories
        //For Obst
        public static readonly Guid SubCatAepfelId = Guid.Parse("00000000-0000-0000-0000-200000000011");
        public static readonly Guid SubCatBananenId = Guid.Parse("00000000-0000-0000-0000-200000000012");
        public static readonly Guid SubCatBirnenId = Guid.Parse("00000000-0000-0000-0000-200000000013");
        public static readonly Guid SubCatErdbeerenId = Guid.Parse("00000000-0000-0000-0000-200000000014");
        public static readonly Guid SubCatHimbeerenId = Guid.Parse("00000000-0000-0000-0000-200000000015");
        public static readonly Guid SubCatKirschenId = Guid.Parse("00000000-0000-0000-0000-200000000016");
        public static readonly Guid SubCatMarillenId = Guid.Parse("00000000-0000-0000-0000-200000000017");
        public static readonly Guid SubCatMelonenId = Guid.Parse("00000000-0000-0000-0000-200000000018");
        public static readonly Guid SubCatPfirsicheId = Guid.Parse("00000000-0000-0000-0000-200000000019");
        public static readonly Guid SubCatTraubenId = Guid.Parse("00000000-0000-0000-0000-200000000020");
        public static readonly Guid SubCatZitronenId = Guid.Parse("00000000-0000-0000-0000-200000000021");
        public static readonly Guid SubCatZwetschkenId = Guid.Parse("00000000-0000-0000-0000-200000000022");
        public static readonly Guid SubCatHeidelbeerenId = Guid.Parse("00000000-0000-0000-0000-200000000023");
        public static readonly Guid SubCatKiwisId = Guid.Parse("00000000-0000-0000-0000-200000000024");
        public static readonly Guid SubCatOrangenId = Guid.Parse("00000000-0000-0000-0000-200000000025");
        //....

        //For Gemuese
        public static readonly Guid SubCatKarottenId = Guid.Parse("00000000-0000-0000-0000-210000000000");
        public static readonly Guid SubCatKartoffelnId = Guid.Parse("00000000-0000-0000-0000-210000000001");
        public static readonly Guid SubCatZwiebelnId = Guid.Parse("00000000-0000-0000-0000-210000000002");
        public static readonly Guid SubCatTomatenId = Guid.Parse("00000000-0000-0000-0000-210000000003");
        public static readonly Guid SubCatGurkenId = Guid.Parse("00000000-0000-0000-0000-210000000004");
        public static readonly Guid SubCatPaprikaId = Guid.Parse("00000000-0000-0000-0000-210000000005");
        public static readonly Guid SubCatKohlrabiId = Guid.Parse("00000000-0000-0000-0000-210000000006");
        public static readonly Guid SubCatKuerbisId = Guid.Parse("00000000-0000-0000-0000-210000000007");
        public static readonly Guid SubCatSalatId = Guid.Parse("00000000-0000-0000-0000-210000000008");
        public static readonly Guid SubCatSellerieId = Guid.Parse("00000000-0000-0000-0000-210000000009");
        public static readonly Guid SubCatSpinatId = Guid.Parse("00000000-0000-0000-0000-210000000010");
        public static readonly Guid SubCatZucchiniId = Guid.Parse("00000000-0000-0000-0000-210000000011");
        public static readonly Guid SubCatBrokkoliId = Guid.Parse("00000000-0000-0000-0000-210000000012");
        public static readonly Guid SubCatBlumenkohlId = Guid.Parse("00000000-0000-0000-0000-210000000013");
        public static readonly Guid SubCatChampignonsId = Guid.Parse("00000000-0000-0000-0000-210000000014");
        public static readonly Guid SubCatEierschwammerlId = Guid.Parse("00000000-0000-0000-0000-210000000015");
        public static readonly Guid SubCatErbsenId = Guid.Parse("00000000-0000-0000-0000-210000000016");
        public static readonly Guid SubCatFisolenId = Guid.Parse("00000000-0000-0000-0000-210000000017");
        public static readonly Guid SubCatLauchId = Guid.Parse("00000000-0000-0000-0000-210000000019");
        //....

        //For Fleisch
        public static readonly Guid SubCatRindfleischId = Guid.Parse("00000000-0000-0000-0000-300000000001");
        public static readonly Guid SubCatSchweinefleischId = Guid.Parse("00000000-0000-0000-0000-300000000002");
        public static readonly Guid SubCatHuehnerfleischId = Guid.Parse("00000000-0000-0000-0000-300000000003");
        public static readonly Guid SubCatPutenfleischId = Guid.Parse("00000000-0000-0000-0000-300000000004");
        public static readonly Guid SubCatKalbfleischId = Guid.Parse("00000000-0000-0000-0000-300000000005");
        public static readonly Guid SubCatLammfleischId = Guid.Parse("00000000-0000-0000-0000-300000000006");
        public static readonly Guid SubCatWildfleischId = Guid.Parse("00000000-0000-0000-0000-300000000007");
        public static readonly Guid SubCatFaschiertesId = Guid.Parse("00000000-0000-0000-0000-300000000008");
        public static readonly Guid SubCatWurstId = Guid.Parse("00000000-0000-0000-0000-300000000009");
        public static readonly Guid SubCatSpeckId = Guid.Parse("00000000-0000-0000-0000-300000000010");
        public static readonly Guid SubCatSchinkenId = Guid.Parse("00000000-0000-0000-0000-300000000011");
        public static readonly Guid SubCatSalamiId = Guid.Parse("00000000-0000-0000-0000-300000000012");
        public static readonly Guid SubCatLeberkaeseId = Guid.Parse("00000000-0000-0000-0000-300000000013");

        //For Fisch
        public static readonly Guid SubCatLachsId = Guid.Parse("00000000-0000-0000-0000-400000000001");
        public static readonly Guid SubCatForelleId = Guid.Parse("00000000-0000-0000-0000-400000000002");
        public static readonly Guid SubCatThunfischId = Guid.Parse("00000000-0000-0000-0000-400000000003");
        public static readonly Guid SubCatSchwertfischId = Guid.Parse("00000000-0000-0000-0000-400000000004");
        public static readonly Guid SubCatKabeljauId = Guid.Parse("00000000-0000-0000-0000-400000000005");
        public static readonly Guid SubCatSeelachsId = Guid.Parse("00000000-0000-0000-0000-400000000006");
        public static readonly Guid SubCatScholleId = Guid.Parse("00000000-0000-0000-0000-400000000007");
        public static readonly Guid SubCatHeilbuttId = Guid.Parse("00000000-0000-0000-0000-400000000008");
        public static readonly Guid SubCatGarnelenId = Guid.Parse("00000000-0000-0000-0000-400000000009");
        public static readonly Guid SubCatHummerId = Guid.Parse("00000000-0000-0000-0000-400000000010");
        public static readonly Guid SubCatKrabbenId = Guid.Parse("00000000-0000-0000-0000-400000000011");
        public static readonly Guid SubCatMuschelnId = Guid.Parse("00000000-0000-0000-0000-400000000012");
        public static readonly Guid SubCatTintenfischId = Guid.Parse("00000000-0000-0000-0000-400000000013");
        public static readonly Guid SubCatAusternId = Guid.Parse("00000000-0000-0000-0000-400000000014");
        public static readonly Guid SubCatKrebsId = Guid.Parse("00000000-0000-0000-0000-400000000015");
        // Markele , Forelle , Pangasius 

        //For Milchprodukte
        public static readonly Guid SubCatMilchId = Guid.Parse("00000000-0000-0000-0000-500000000001");
        public static readonly Guid SubCatJoghurtId = Guid.Parse("00000000-0000-0000-0000-500000000002");
        public static readonly Guid SubCatKaeseId = Guid.Parse("00000000-0000-0000-0000-500000000003");
        public static readonly Guid SubCatButterId = Guid.Parse("00000000-0000-0000-0000-500000000004");
        public static readonly Guid SubCatTopfenId = Guid.Parse("00000000-0000-0000-0000-500000000005");
        public static readonly Guid SubCatSahneId = Guid.Parse("00000000-0000-0000-0000-500000000006");
        public static readonly Guid SubCatEierId = Guid.Parse("00000000-0000-0000-0000-500000000007");
        public static readonly Guid SubCatQuarkId = Guid.Parse("00000000-0000-0000-0000-500000000008");
        public static readonly Guid SubCatFrischkaeseId = Guid.Parse("00000000-0000-0000-0000-500000000009");
        public static readonly Guid SubCatSchlagobersId = Guid.Parse("00000000-0000-0000-0000-500000000010");
        public static readonly Guid SubCatKefirId = Guid.Parse("00000000-0000-0000-0000-500000000011");
        public static readonly Guid SubCatMozzarellaId = Guid.Parse("00000000-0000-0000-0000-500000000012");
        public static readonly Guid SubCatFetaId = Guid.Parse("00000000-0000-0000-0000-500000000013");
        public static readonly Guid SubCatParmesanId = Guid.Parse("00000000-0000-0000-0000-500000000014");
        public static readonly Guid SubCatRicottaId = Guid.Parse("00000000-0000-0000-0000-500000000015");
        public static readonly Guid SubCatGoudaId = Guid.Parse("00000000-0000-0000-0000-500000000016");
        public static readonly Guid SubCatEmmentalerId = Guid.Parse("00000000-0000-0000-0000-500000000017");
        public static readonly Guid SubCatBrieId = Guid.Parse("00000000-0000-0000-0000-500000000018");
        public static readonly Guid SubCatCamembertId = Guid.Parse("00000000-0000-0000-0000-500000000019");
        public static readonly Guid SubCatMascarponeId = Guid.Parse("00000000-0000-0000-0000-500000000020");
        public static readonly Guid SubCatGorgonzolaId = Guid.Parse("00000000-0000-0000-0000-500000000021");
        public static readonly Guid SubCatBergkaeseId = Guid.Parse("00000000-0000-0000-0000-500000000022");
        public static readonly Guid SubCatBergbaronId = Guid.Parse("00000000-0000-0000-0000-500000000023");
        public static readonly Guid SubCatBergbauernId = Guid.Parse("00000000-0000-0000-0000-500000000024");

        //For Backwaren
        public static readonly Guid SubCatBrotId = Guid.Parse("00000000-0000-0000-0000-600000000001");
        public static readonly Guid SubCatBroetchenId = Guid.Parse("00000000-0000-0000-0000-600000000002");
        public static readonly Guid SubCatSemmelnId = Guid.Parse("00000000-0000-0000-0000-600000000003");
        public static readonly Guid SubCatToastbrotId = Guid.Parse("00000000-0000-0000-0000-600000000004");
        public static readonly Guid SubCatBaguetteId = Guid.Parse("00000000-0000-0000-0000-600000000005");
        public static readonly Guid SubCatKipferlId = Guid.Parse("00000000-0000-0000-0000-600000000006");
        public static readonly Guid SubCatBrezelId = Guid.Parse("00000000-0000-0000-0000-600000000007");
        public static readonly Guid SubCatKuchenId = Guid.Parse("00000000-0000-0000-0000-600000000008");
        public static readonly Guid SubCatTortenId = Guid.Parse("00000000-0000-0000-0000-600000000009");
        public static readonly Guid SubCatKekseId = Guid.Parse("00000000-0000-0000-0000-600000000010");
        public static readonly Guid SubCatWaffelnId = Guid.Parse("00000000-0000-0000-0000-600000000011");
        public static readonly Guid SubCatMuffinsId = Guid.Parse("00000000-0000-0000-0000-600000000012");
        public static readonly Guid SubCatCroissantsId = Guid.Parse("00000000-0000-0000-0000-600000000013");
        public static readonly Guid SubCatDonutsId = Guid.Parse("00000000-0000-0000-0000-600000000014");
        public static readonly Guid SubCatStrudelId = Guid.Parse("00000000-0000-0000-0000-600000000015");
        public static readonly Guid SubCatBiskuitId = Guid.Parse("00000000-0000-0000-0000-600000000016");
        public static readonly Guid SubCatZimtschneckenId = Guid.Parse("00000000-0000-0000-0000-600000000017");

        //For Suesswaren
        public static readonly Guid SubCatSchokoladeId = Guid.Parse("00000000-0000-0000-0000-700000000001");
        public static readonly Guid SubCatKekseSuessId = Guid.Parse("00000000-0000-0000-0000-700000000002");
        public static readonly Guid SubCatBonbonsId = Guid.Parse("00000000-0000-0000-0000-700000000003");
        public static readonly Guid SubCatGummibaerchenId = Guid.Parse("00000000-0000-0000-0000-700000000004");
        public static readonly Guid SubCatKaugummiId = Guid.Parse("00000000-0000-0000-0000-700000000005");
        public static readonly Guid SubCatSchaumzuckerId = Guid.Parse("00000000-0000-0000-0000-700000000006");
        public static readonly Guid SubCatLakritzId = Guid.Parse("00000000-0000-0000-0000-700000000007");

        //For Getraenke
        public static readonly Guid SubCatWasserId = Guid.Parse("00000000-0000-0000-0000-800000000001");
        public static readonly Guid SubCatSaftId = Guid.Parse("00000000-0000-0000-0000-800000000002");
        public static readonly Guid SubCatLimonadeId = Guid.Parse("00000000-0000-0000-0000-800000000003");
        public static readonly Guid SubCatBierId = Guid.Parse("00000000-0000-0000-0000-800000000004");
        public static readonly Guid SubCatWeinId = Guid.Parse("00000000-0000-0000-0000-800000000005");
        public static readonly Guid SubCatSektId = Guid.Parse("00000000-0000-0000-0000-800000000006");
        public static readonly Guid SubCatSchnapsId = Guid.Parse("00000000-0000-0000-0000-800000000007");
        public static readonly Guid SubCatLikörId = Guid.Parse("00000000-0000-0000-0000-800000000008");

        //For Tiefkuehl
        public static readonly Guid SubCatPizzaId = Guid.Parse("00000000-0000-0000-0000-900000000001");
        public static readonly Guid SubCatFischTiefkuehlId = Guid.Parse("00000000-0000-0000-0000-900000000002");
        public static readonly Guid SubCatGemueseTiefkuehlId = Guid.Parse("00000000-0000-0000-0000-900000000003");
        public static readonly Guid SubCatFleischTiefkuehlId = Guid.Parse("00000000-0000-0000-0000-900000000004");
        public static readonly Guid SubCatEisId = Guid.Parse("00000000-0000-0000-0000-900000000005");
        public static readonly Guid SubCatKuchenTiefkuehlId = Guid.Parse("00000000-0000-0000-0000-900000000006");
        public static readonly Guid SubCatFertiggerichteId = Guid.Parse("00000000-0000-0000-0000-900000000007");
        public static readonly Guid SubCatPommesId = Guid.Parse("00000000-0000-0000-0000-900000000008");
        public static readonly Guid SubCatNuggetsId = Guid.Parse("00000000-0000-0000-0000-900000000009");

        //For Sonstiges
        public static readonly Guid SubCatSalzId = Guid.Parse("00000000-0000-0000-0000-100000000000");
        public static readonly Guid SubCatPfefferId = Guid.Parse("00000000-0000-0000-0000-100000000001");
        public static readonly Guid SubCatOelId = Guid.Parse("00000000-0000-0000-0000-100000000002");
        public static readonly Guid SubCatEssigId = Guid.Parse("00000000-0000-0000-0000-100000000003");
        public static readonly Guid SubCatZuckerId = Guid.Parse("00000000-0000-0000-0000-100000000004");
        public static readonly Guid SubCatMehlId = Guid.Parse("00000000-0000-0000-0000-100000000005");
        public static readonly Guid SubCatReisId = Guid.Parse("00000000-0000-0000-0000-100000000006");
        public static readonly Guid SubCatNudelnId = Guid.Parse("00000000-0000-0000-0000-100000000007");
        public static readonly Guid SubCatKartoffelchipsId = Guid.Parse("00000000-0000-0000-0000-100000000008");
        public static readonly Guid SubCatPopcornId = Guid.Parse("00000000-0000-0000-0000-100000000009");
        public static readonly Guid SubCatNuesseId = Guid.Parse("00000000-0000-0000-0000-100000000010");
        public static readonly Guid SubCatKaffeeId = Guid.Parse("00000000-0000-0000-0000-100000000011");
        public static readonly Guid SubCatTeeId = Guid.Parse("00000000-0000-0000-0000-100000000012");
        public static readonly Guid SubCatKakaoId = Guid.Parse("00000000-0000-0000-0000-100000000013");
        public static readonly Guid SubCatMuesliId = Guid.Parse("00000000-0000-0000-0000-100000000014");
        public static readonly Guid SubCatMarmeladeId = Guid.Parse("00000000-0000-0000-0000-100000000015");
        public static readonly Guid SubCatHonigId = Guid.Parse("00000000-0000-0000-0000-100000000016");
        public static readonly Guid SubCatSenfId = Guid.Parse("00000000-0000-0000-0000-100000000017");
        public static readonly Guid SubCatMayonnaiseId = Guid.Parse("00000000-0000-0000-0000-100000000018");
        public static readonly Guid SubCatKetchupId = Guid.Parse("00000000-0000-0000-0000-100000000019");
        public static readonly Guid SubCatSauceId = Guid.Parse("00000000-0000-0000-0000-100000000020");
        public static readonly Guid SubCatSuppeId = Guid.Parse("00000000-0000-0000-0000-100000000021");
        public static readonly Guid SubCatGewuerzeId = Guid.Parse("00000000-0000-0000-0000-100000000022");
        public static readonly Guid SubCatBackpulverId = Guid.Parse("00000000-0000-0000-0000-100000000023");


        // Icon ids
        public static readonly Guid IconObstId = Guid.Parse("00000000-0000-0000-0010-001000000001");
        public static readonly Guid IconGemueseId = Guid.Parse("00000000-0000-0000-0010-001000000002");
        public static readonly Guid IconFleischId = Guid.Parse("00000000-0000-0000-0010-001000000003");
        public static readonly Guid IconFischId = Guid.Parse("00000000-0000-0000-0010-001000000004");
        public static readonly Guid IconMilchProdukteId = Guid.Parse("00000000-0000-0000-0010-001000000005");
        public static readonly Guid IconBackwarenId = Guid.Parse("00000000-0000-0000-0010-001000000006");
        public static readonly Guid IconSuesswarenId = Guid.Parse("00000000-0000-0000-0010-001000000007");
        public static readonly Guid IconGetraenkeId = Guid.Parse("00000000-0000-0000-0010-001000000008");
        public static readonly Guid IconTiefkuehlId = Guid.Parse("00000000-0000-0000-0010-001000000009");
        public static readonly Guid IconSonstigesId = Guid.Parse("00000000-0000-0000-0010-001000000010");

    }
}
