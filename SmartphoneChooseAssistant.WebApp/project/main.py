import fuzzy_operators
import model
import inference_mamdani
import random
import numpy as np
import membership_functions
import fuzzifier
import inference_mamdani
import defuzzifier
import rule_base_function

inference_mamdani.preprocessing(model.input_lvs, model.output_lv)

'''
for i_1 in range(-100_000, 0, 500):
    for i_2 in range(2048):
        for i_3 in range(20_000):
            for i_4 in range(70):
                crisp_values = (i_1, i_2, i_3, i_4)
                result = inference_mamdani.process(model.input_lvs, model.output_lv, model.rule_base, crisp_values)
                print(crisp_values, result)'''

#rule_base_function.generate_rule_base(model)


for lv in model.input_lvs:
    lv['U'] = abs(lv['U'])
    #fuzzy_operators.draw_lv(lv)

# fuzzy_operators.draw_lv(model.output_lv)


crisp = (3000*-1, 512, 10000, 50)
print("Crisp ", crisp)
fuzzy_values = fuzzifier.fuzzification(crisp, model.input_lvs)
act_rules = inference_mamdani.activated_rules(fuzzy_values, model.rule_base)
res_1 = inference_mamdani.implication(fuzzy_values, act_rules, model.output_lv)

#for mf in res_1:
#    fuzzy_operators.draw_fuzzy_set(model.output_lv['U'], mf)

res_2 = inference_mamdani.aggregation(res_1)
#fuzzy_operators.draw_fuzzy_set(model.output_lv['U'], res_2)

res_values = defuzzifier.__cog(model.output_lv['U'], res_2)
#print(res_values)

word = []

for term, mf in model.output_lv['terms'].items():
    sm = defuzzifier.jaccard_measure(mf, res_2)
    word.append([term, sm])

res_word = max(word, key=lambda item: item[1])


print()
print("result: ", res_word)
print()

print(act_rules)

for item in fuzzy_values:
    print(item, fuzzy_values[item])




