

def generate_rule_base(model):
    words = list(model.output_lv['terms'].keys())
    one_word_weight = 1 / len(model.input_lvs[0]['terms'])

    i_1_one_term_weight = one_word_weight * (1 / len(model.input_lvs[0]['terms']))
    i_2_one_term_weight = one_word_weight * (1 / len(model.input_lvs[1]['terms']))
    i_3_one_term_weight = one_word_weight * (1 / len(model.input_lvs[2]['terms']))
    i_4_one_term_weight = one_word_weight * (1 / len(model.input_lvs[3]['terms']))

    for index_1, i_1 in enumerate(model.input_lvs[0]['terms'].keys()):
        i_1_weight = i_1_one_term_weight * (index_1 + 1)
        for index_2, i_2 in enumerate(model.input_lvs[1]['terms'].keys()):
            i_2_weight = i_2_one_term_weight * (index_2 + 1)
            for index_3, i_3 in enumerate(model.input_lvs[2]['terms'].keys()):
                i_3_weight = i_3_one_term_weight * (index_3 + 1)
                for index_4, i_4 in enumerate(model.input_lvs[3]['terms'].keys()):
                    i_4_weight = i_4_one_term_weight * (index_4 + 1)

                    total_weight = i_1_weight + i_2_weight + i_3_weight + i_4_weight
                    thenWord = ""

                    for index, word in enumerate(model.output_lv['terms'].keys()):
                        if total_weight >= index * one_word_weight:
                            thenWord = word

                    res = f"(('{i_1}', '{i_2}', '{i_3}', '{i_4}'), '{thenWord}'),"
                    print(res)