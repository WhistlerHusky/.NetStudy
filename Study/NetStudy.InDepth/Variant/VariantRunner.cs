using System;
using NetStudy.Core;

namespace NetStudy.InDepth.Variant
{
    public class VariantRunner : IRunner
    {
        public void Run()
        {
            ///////////////////////////Covariant/////////////////////////////////
            //자식 Type의 인스턴스를 부모 Type의 변수에 대입가능한걸 Covariant 라고한다. IEnumerable<out T>
            //이 경우 내부에서 해당 인스턴스의 특정 변수나, 메소드를 사용하지 않고, 해당 객체를 보관하다가 돌려만 준다.
            //부모 클래스의 경우 자식 클래스를 담을수 있으니 당연히 가능
            //out 키워드가 뜻하는건 해당 객체를 리턴만 하지, 해당 인스턴스의 멤버나 함수를 사용하진 않는다는거다
            ICovariance<Lion> lionCovarianct = new CovariantLion();
            ICovariance<Animal> animalConvarianct = lionCovarianct;

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

            //부모 Type의 인스턴스를 를 자식 Type의 변수에 대입가능한걸 ContraVariant 라고한다.IComparer<in T>
            //이 경우 내부에서 해당 인스턴스의 특정 변수나, 멤소드를 사용가능한데 이는 자식클래스가 부모클래스의 모든 변수나, 함수를 상속받았기 때문
            //다만 객체를 리턴은 못함. 
            //in 키워드는 해당 인스턴스의 메소드나, 함수를 사용은 하지만, 해당 인스턴스를 리턴하진 않는다는거다.(리턴하려면 out이여야됨)
            IContravariance<Animal> animalContravarianct = new FindKingAnimal();
            IContravariance<Lion> lionContravarianct = animalContravarianct;
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