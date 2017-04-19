using System;

namespace Pilots.Variant
{
    public class VariantRunner : IRunner
    {
        public void Run()
        {
            ///////////////////////////Covariant/////////////////////////////////
            //자식 Type의 객체를 부모 Type의 변수에 대입가능한걸 Covariant 라고한다.(바꿔 부모 클래스 타입 변수에 자식 클래스 객체 대입 가능) IEnumerable<out T>
            ICovarianct<Lion> lionCovarianct = new CovariantLion();
            ICovarianct<Animal> animalConvarianct = lionCovarianct;

            //비록 ICovarianct<Animal> type 변수지만 실제 객체는 CovariantLion 임으로 실제는 Lion이 리턴됨.
            var theKing = animalConvarianct.GetKing();
            //Lion 이 출력됨
            Console.WriteLine(theKing.Name);

            //다시 CovariantAnimal type 객체를 넣어주면.
            animalConvarianct = new CovariantAnimal();
            theKing = animalConvarianct.GetKing();
            //Animal 이 출력됨
            Console.WriteLine(theKing.Name);

            // CovariantLion type의 변수에 CovariantAnimal type 객체 대입 불가능 (Contranvariant 면 가능)
            //lionCovarianct = animalConvarianct; //compiler error

            ///////////////////////////Contravariant/////////////////////////////////
            Lion aLion = new Lion("shortNameLionA", 100);
            Lion zLion = new Lion("longNameLionABCDEF", 1);

            //부모 Type의 객체를 자식 Type의 변수에 대입가능한걸 ContraVariant 라고한다. (바꿔말해 자식 클래스 변수 타입에 부모 클래스 객체 대입 가능) IComparer<in T>
            IContravarianct<Animal> animalContravarianct = new FindKingAnimal();
            IContravarianct<Lion> lionContravarianct = animalContravarianct;
            //비록 Lion type 변수지만 실제 객체는 MakingKingAnimal 임으로 이름 길이가 긴 longNameLionABCDEF 가 출력됨.
            Console.WriteLine(lionContravarianct.GetKing(aLion, zLion));

            //다시 MakingKingLion type 객체를 넣어주면
            lionContravarianct = new FindKingLion();
            // 이번에는 Power가 높은 shortNameLionA 가 출력됨.
            Console.WriteLine(lionContravarianct.GetKing(aLion, zLion));

            // 아래 MakingKingAnimal type 변수에 MakingKingLion객체는 대입불가능!(Covariant 였으면 가능했)
            // animalContravarianct = lionContravarianct; //compiler error
        }
    }
}