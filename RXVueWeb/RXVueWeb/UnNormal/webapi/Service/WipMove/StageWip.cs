using NPOI.SS.Formula.Functions;
using System.Linq;
using webapi.Bean.Rep;
using webapi.Entity.Rxrep2;
using webapi.Bean.Chart;
using Microsoft.Office.Interop.Outlook;

namespace webapi.Service.WipMove
{
    public class StageWip {

        public static List<WipMoveBean> GetList<T>(List<T> items) where T : WipRepBean
        {
            List<WipMoveBean> wipMoves = new List<WipMoveBean> { };
            List<String> flagList = new List<string>();
            List<String> flagCodeList = GetFlagList(items, flagList);
            List<int> holdList = GetStateList(items, flagCodeList, "HOLD");
            List<int> RunList = GetStateList(items, flagCodeList, "RUN");
            List<int> waitList = GetStateList(items, flagCodeList, "WAIT");
            // 在这里使用 flagList、holdList、activeList 和 waitList 进行后续操作
            List<string>  HoldList = holdList.Select(x => x.ToString()).ToList();
            List<string> runList = RunList.Select(x => x.ToString()).ToList();
            List<string> WaitList = waitList.Select(x => x.ToString()).ToList();

            WipMoveBean x = new WipMoveBean("x轴", flagList.ToArray());
            WipMoveBean hold = new WipMoveBean("HOLD", HoldList.ToArray());
            WipMoveBean Run = new WipMoveBean("RUN", runList.ToArray());
            WipMoveBean Wait = new WipMoveBean("Wait", WaitList.ToArray());
            wipMoves.Add(x);
            wipMoves.Add(hold);
            wipMoves.Add(Run);
            wipMoves.Add(Wait);
            return wipMoves;
        }

        private static List<String> GetFlagList<T>(List<T> items,List<String> x) where T : WipRepBean
        {
            List<String> flagList = new List<String>();
            foreach (T item in items)
            {
                string flag = item.PRODUCT+item.Flag + item.RecpName + item.StepCode;
                if (!flagList.Contains(flag))
                {
                    flagList.Add(flag);
                    x.Add(item.Flag);
                }
            }
            return flagList;
        }

        private static List<int> GetStateList<T>(List<T> items, List<string> FlagList, string state) where T : WipRepBean
        {
            List<int> stateList = new List<int>();

            foreach (string flag in FlagList)
            {
                int sum = 0;
                foreach (T item in items)
                {
                    string tar = item.PRODUCT + item.Flag + item.RecpName + item.StepCode;
                    if (item.State == state && tar==flag)
                    {
                        sum += item.Sum;
                    }
                }
                stateList.Add(sum);
            }

            return stateList;
        }

        private static List<int> GetMove<T>(List<T> items, List<string> FlagList) where T : WipRepBean
        {
            List<int> stateList = new List<int>();

            foreach (string flag in FlagList)
            {
                int sum = 0;
                foreach (T item in items)
                {
                    string tar = item.PRODUCT + item.Flag + item.RecpName + item.StepCode;
                    if ( tar == flag)
                    {
                        sum += item.Sum;
                    }
                }
                stateList.Add(sum);
            }

            return stateList;
        }


        public static List<WipMoveBean> MoveWipList<T>(List<T> step, List<T> MOVE, List<T> WIP) where T : WipRepBean
        {
            List<WipMoveBean> wipMoves = new List<WipMoveBean> { };

            List<string> allStepCodes = step.Select(s => s.StepCode).ToList();

            List<WipRepBean> stepdescTest = new List<WipRepBean> { };
            // 遍历MOVE和WIP列表
            foreach (T moveItem in MOVE)
            {
                // 如果stepcode存在于allStepCodes中，则将对应的stepdesc添加到wipMoves中
                if (allStepCodes.Contains(moveItem.StepCode))
                {
                    stepdescTest.Add(new WipRepBean {PRODUCT= moveItem.PRODUCT, StepCode = moveItem.StepCode, RecpName=moveItem.RecpName ,Flag = moveItem.Flag }); ;
                }
            }

            foreach (T wipItem in WIP)
            {
                // 如果stepcode存在于allStepCodes中，则将对应的stepdesc添加到wipMoves中
                if (allStepCodes.Contains(wipItem.StepCode))
                {
                    stepdescTest.Add(new WipRepBean { PRODUCT = wipItem.PRODUCT, StepCode = wipItem.StepCode, RecpName = wipItem.RecpName, Flag = wipItem.Flag });
                }
            }

            // 如果stepcode不存在于MOVE和WIP中，则从step列表中随机选择一个stepcode对应的stepdesc添加到wipMoves中
            foreach (string stepCode in allStepCodes)
            {
                if (!stepdescTest.Any(w => w.StepCode == stepCode))
                {
                    T randomStep = step.FirstOrDefault(s => s.StepCode == stepCode);
                    if (randomStep != null)
                    {
                        stepdescTest.Add(new WipRepBean { PRODUCT = randomStep.PRODUCT, StepCode = randomStep.StepCode, RecpName = randomStep.RecpName, Flag = randomStep.Flag });
                    }
                }
            }
            stepdescTest = stepdescTest.OrderBy(e => e.StepCode).ToList();

            List<String> flagList = new List<string>();
            List<String> flagCodeList = GetFlagList(stepdescTest, flagList);
            List<int> holdList = GetStateList(WIP, flagCodeList, "HOLD");
            List<int> RunList = GetStateList(WIP, flagCodeList, "RUN");
            List<int> waitList = GetStateList(WIP, flagCodeList, "WAIT");

            //int sum = holdList.Sum() + RunList.Sum() + waitList.Sum();
            //int sum2 = 0;
            //foreach (var i in WIP) {
            //    sum2 += i.Sum;
            //}
            List<int> MoveList = GetMove(MOVE, flagCodeList);

            //int sum = MoveList.Sum();
            //int sum2 = 0;
            //foreach (var i in MOVE)
            //{
            //    sum2 += i.Sum;
            //}
            List<string> HoldList = holdList.Select(x => x.ToString()).ToList();
            List<string> runList = RunList.Select(x => x.ToString()).ToList();
            List<string> WaitList = waitList.Select(x => x.ToString()).ToList();
            List<string> move = MoveList.Select(x => x.ToString()).ToList();
            WipMoveBean x = new WipMoveBean("x轴", flagList.ToArray());
            WipMoveBean hold = new WipMoveBean("HOLD", HoldList.ToArray());
            WipMoveBean Run = new WipMoveBean("RUN", runList.ToArray());
            WipMoveBean Wait = new WipMoveBean("Wait", WaitList.ToArray());
            WipMoveBean Move = new WipMoveBean("MOVE", move.ToArray());
            wipMoves.Add(x);
            wipMoves.Add(hold);
            wipMoves.Add(Run);
            wipMoves.Add(Wait);
            wipMoves.Add(Move);
            Console.Write("成功");
            return wipMoves;
        }


    }
}
